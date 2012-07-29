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
using DataStore.Common.Model;
using StatisticsProxyImpl.factories;
using DataStore.DAO;

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
            _indicatorRepository.Connection = ConnectionSettings.CreateDBConnection();

            _factory = factory;
        }

        public IndicatorMetadata GetMetadata(int sourceid, int indicatorid)
        {
            Indicator indicator = null;
            using (_indicatorRepository.Connection = ConnectionSettings.CreateDBConnection())
            {
                indicator = _indicatorRepository.GetIndicatorById(sourceid, indicatorid);
            }

            if (indicator == null) return null;

            using (IStatisticsRequestStrategy request = _factory.GetStatisticRequestStrategy(indicator.Provider.ServiceURL, _configurationKey)) 
            {
                IndicatorMetadata metadata = request.GetMetadata(indicator.SourceID);
                metadata.ID = indicator.ID.ToString();
                metadata.SourceID = indicator.Provider.ID;
                metadata.SourceName = indicator.Provider.Name;
                metadata.SourceNameAbbr = indicator.Provider.NameAbbr;

                return metadata;
            }
        }

        public IndicatorValues GetIndicatorValues(int sourceid, int indicatorid, IEnumerable<DimensionFilter> filterDimensions, IEnumerable<DimensionFilter> projectedDimensions)
        {
            Indicator indicator = null;
            using (_indicatorRepository.Connection = ConnectionSettings.CreateDBConnection())
            {
                indicator = _indicatorRepository.GetIndicatorById(sourceid, indicatorid);
            }
            if (indicator == null) return null;

            IEnumerable<IndicatorValue> values = null;
            using (IStatisticsRequestStrategy request = _factory.GetStatisticRequestStrategy(indicator.Provider.ServiceURL, _configurationKey))
            {
                values = request.GetValues(indicator.SourceID, filterDimensions, projectedDimensions);
            }

            if(values == null) return null;

            return new IndicatorValues { 
                Values = values,
                Location = null //TODO: resolve location
            };
        }

        public IndicatorValueRange GetIndicatorValuesRange(int sourceid, int indicatorid, IEnumerable<DimensionFilter> filterDimensions, IEnumerable<DimensionFilter> projectedDimensions, string shapeLevel)
        {
            Indicator indicator = null;
            using (_indicatorRepository.Connection = ConnectionSettings.CreateDBConnection())
            {
                indicator = _indicatorRepository.GetIndicatorById(sourceid, indicatorid);
            }
            if (indicator == null) return null;

            IndicatorValueRange range = null;
            using (IStatisticsRequestStrategy request = _factory.GetStatisticRequestStrategy(indicator.Provider.ServiceURL, _configurationKey))
            {
                range = request.GetValuesRange(indicator.SourceID, filterDimensions, projectedDimensions, shapeLevel);
            }

            return range;
        }
    }
}
