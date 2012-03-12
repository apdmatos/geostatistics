using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsProxyServiceDefenitions.interfaces;
using ProviderDataContracts.Metadata;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Filters;
using System.ServiceModel;
using ProviderDataContracts.Values;
using StatisticsProxyImpl.requesters;
using DataStore.Common.Data_Interfaces;
using DataStore.DAO;
using DataStore.Common.Model;
using StatisticsProxyImpl.factories;

namespace StatisticsProxyImpl
{
    public class DefaultStatisticsProxyImpl : IStatisticsProxyService
    {
        private IStatisticsProviderRequestFactory _factory;
        private IIndicatorDAO _indicatorRepository;
        private string _configurationKey;

        public DefaultStatisticsProxyImpl(string configKey, IIndicatorDAO indicatorRepository, IStatisticsProviderRequestFactory factory) 
        {
            _configurationKey = configKey;
            _indicatorRepository = indicatorRepository;
            _factory = factory;
        }

        public IndicatorMetadata GetMetadata(int sourceid, int indicatorid)
        {
            Indicator indicator = _indicatorRepository.GetIndicatorById(sourceid, indicatorid);
            
            using (IStatisticsRequestStrategy request = _factory.GetStatisticRequestStrategy(indicator.Provider.ServiceURL, _configurationKey)) 
            {
                return request.GetMetadata(indicator.SourceID);
            }
        }

        // TODO: put this on an helper class to agregate this values and join filters
        public DataSerie GetDataSerie(int sourceid, int indicatorid, DimensionFilter axisDimension, IEnumerable<DimensionFilter> selectedDimensions) 
        {
            Indicator indicator = _indicatorRepository.GetIndicatorById(sourceid, indicatorid);

            //join filters
            List<DimensionFilter> filters = JoinFilters(selectedDimensions, axisDimension);

            // get values
            IEnumerable<IndicatorValue> values = null;
            using (IStatisticsRequestStrategy request = _factory.GetStatisticRequestStrategy(indicator.Provider.ServiceURL, _configurationKey))
            {
                values = request.GetValues(indicator.SourceID, filters);
            }

            // group values
            Dictionary<string, DataSerieValues> groupedValues = new Dictionary<string, DataSerieValues>();

            // this dictionary contains: axisDimensionAttribute -> DimensionId -> List<AttributeId>
            Dictionary<string, Dictionary<string, DimensionAttributesHelper>> selectedDimensionsHelper = new Dictionary<string, Dictionary<string, DimensionAttributesHelper>>();
            foreach (var value in values)
            {
                DimensionFilter axisFilter = value.Filters.Where(f => f.DimensionID == axisDimension.DimensionID).FirstOrDefault();
                string axisAttributeId = axisFilter.AttributeIDs.First();
                if (!groupedValues.ContainsKey(axisAttributeId))
                {
                    DataSerieValues dataSerie = new DataSerieValues
                    {
                        Value = 0,
                        AxisDimension = axisFilter,
                        SelectedDimensions = value.Filters
                    };

                    groupedValues.Add(axisAttributeId, dataSerie);
                }

                AddSelectedDimensions(selectedDimensionsHelper, groupedValues[axisAttributeId].AxisDimension, value.Filters);
                groupedValues[axisAttributeId].Value += value.Value;
            }

            return new DataSerie 
            {
                Values = groupedValues.Values.ToList()
            };
        }


        private class DimensionAttributesHelper 
        {
            public Dictionary<string, bool> UsedAttributes;
            public IEnumerable<string> AttributesEnumerable { get { return UsedAttributes.Keys; } }
        }

        private void AddSelectedDimensions(
            Dictionary<string, Dictionary<string, DimensionAttributesHelper>> selectedDimensionsHelper,
            DimensionFilter axisDimension,
            IEnumerable<DimensionFilter> filters)
        {

            var axisAttributeId = axisDimension.AttributeIDs.First();

            // get HashTable for current axis dimension
            Dictionary<string, DimensionAttributesHelper> selectedDimensionsHashTable = null;
            if (selectedDimensionsHelper.ContainsKey(axisAttributeId))
                selectedDimensionsHashTable = selectedDimensionsHelper[axisAttributeId];
            else
            {
                selectedDimensionsHashTable = new Dictionary<string, DimensionAttributesHelper>();
                selectedDimensionsHelper.Add(axisAttributeId, selectedDimensionsHashTable);
            }


            foreach (var filter in filters)
            {
                if (selectedDimensionsHashTable.ContainsKey(filter.DimensionID))
                {
                    if (!selectedDimensionsHashTable[filter.DimensionID].UsedAttributes.ContainsKey(filter.AttributeIDs.First()))
                    {
                        selectedDimensionsHashTable[filter.DimensionID].UsedAttributes.Add(filter.AttributeIDs.First(), true);
                    }
                }
                else
                {
                    DimensionAttributesHelper attrs = new DimensionAttributesHelper
                    {
                        UsedAttributes = new Dictionary<string, bool> { 
                            { filter.AttributeIDs.First(), true }
                        }
                    };
                    filter.AttributeIDs = attrs.AttributesEnumerable;
                    selectedDimensionsHashTable.Add(filter.DimensionID, attrs);
                }
            }
        }

        private List<DimensionFilter> JoinFilters(IEnumerable<DimensionFilter> selected, DimensionFilter axis)
        {

            bool merged = false;
            List<DimensionFilter> filters = new List<DimensionFilter>();
            foreach (var filter in selected)
            {
                if (filter.DimensionID == axis.DimensionID)
                {
                    IEnumerable<string> distinctValues = filter.AttributeIDs.Concat(axis.AttributeIDs).Distinct();
                    List<string> attrs = new List<string>(distinctValues);

                    filters.Add(new DimensionFilter { 
                        AttributeIDs = attrs,
                        DimensionID = filter.DimensionID
                    });

                    merged = true;
                }
                else
                    filters.Add(filter);
            }

            if (!merged) {
                filters.Add(axis);
            }

            return filters;
        }
    }
}
