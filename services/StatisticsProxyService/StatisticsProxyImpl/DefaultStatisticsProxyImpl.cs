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
            Dictionary<string, Dictionary<string, List<string>>> selectedDimensionsHelper = new Dictionary<string, Dictionary<string, List<string>>>();
            foreach (var value in values)
            {
                DimensionFilter axisFilter = value.Filters.Where(f => f.DimensionID == axisDimension.DimensionID).FirstOrDefault();
                string axisAttributeId = axisFilter.AttributeIDs.First();
                if (!groupedValues.ContainsKey(axisFilter.DimensionID))
                {
                    DataSerieValues dataSerie = new DataSerieValues
                    {
                        Value = 0,
                        AxisDimension = axisFilter,
                        SelectedDimensions = value.Filters
                    };

                    groupedValues.Add(axisAttributeId, dataSerie);
                }

                //AddSelectedDimensions(selectedDimensionsHelper, groupedValues[axisAttributeId], value.Filters);
                groupedValues[axisAttributeId].Value += value.Value;
            }

            return new DataSerie 
            {
                Values = groupedValues.Values.ToList()
            };
        }

        //private void AddSelectedDimensions(
        //    Dictionary<string, Dictionary<string, List<string>>> selectedDimensionsHelper,
        //    DataSerieValues dataSerieValues,
        //    IEnumerable<DimensionFilter> filters)
        //{

        //    var axisAttributeId = dataSerieValues.AxisDimension.AttributeIDs.First();

        //    // get HashTable for current axis dimension
        //    Dictionary<string, List<string>> selectedDimensionsHashTable = null;
        //    if (selectedDimensionsHelper.ContainsKey(axisAttributeId))
        //        selectedDimensionsHashTable = selectedDimensionsHelper[axisAttributeId];
        //    else
        //    {
        //        selectedDimensionsHashTable = new Dictionary<string, List<string>>();
        //        selectedDimensionsHelper.Add(axisAttributeId, selectedDimensionsHashTable);
        //    }


        //    foreach (var filter in filters)
        //    {
        //        if (selectedDimensionsHashTable.ContainsKey(filter.DimensionID))
        //        {
        //            if (!selectedDimensionsHashTable[filter.DimensionID].ContainsKey(filter.AttributeIDs.First())) {

        //                selectedDimensionsHashTable[filter.DimensionID] = new Dictionary<string, List<string>> { 
        //                    { filter.AttributeIDs.First(), new List<string> {  } }
        //                };


        //            }
        //        }
        //        else
        //        {

        //            // dimension does not exist

        //            if (dataSerieValues.SelectedDimensions == null)
        //                dataSerieValues.SelectedDimensions = new List<DimensionFilter>();

        //            ((List<DimensionFilter>)dataSerieValues.SelectedDimensions).Add(filter);

        //            // register the added selected dimensions on hashtable
        //            selectedDimensionsHashTable.Add(
        //                filter.DimensionID,
        //                new Dictionary<string, DimensionFilter> { 
        //                    { filter.AttributeIDs.First(), filter }
        //                });
        //        }
        //    }

        //    var axisAttributeId = dataSerieValues.AxisDimension.AttributeIDs.First();
        //    Dictionary<string, bool> selectedDimensions = selectedDimensionsHelper[axisAttributeId];

        //    if (!selectedDimensions.ContainsKey(axisAttributeId))
        //    {

        //    }
        //}

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
