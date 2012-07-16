using Ninject.Modules;
using StatisticsProxyServiceDefenitions.interfaces;
using StatisticsProxyImpl;
using System.Configuration;
using DataStore.DAO;
using DataStore.Common.Data_Interfaces;
using StatisticsProxyImpl.requesters;
using StatisticsProxyImpl.factories;
using DependencyInjection.factories;
using Ninject;

namespace DependencyInjection
{
    public class DependencyInjectionNinjectModule : NinjectModule
    {
        private string _databaseConfigKey;
        private string _endpointConfigKey;

        public DependencyInjectionNinjectModule(string databaseConfigurationKey, string endpointConfigKey)
        {
            _databaseConfigKey = databaseConfigurationKey;
            _endpointConfigKey = endpointConfigKey;
        }

        public override void Load()
        {
            ConnectionSettings.SetConnectionSettings(
                ConfigurationManager.ConnectionStrings[_databaseConfigKey].ConnectionString,
                ConfigurationManager.ConnectionStrings[_databaseConfigKey].ProviderName);

            //Injects the constructors of all DI-ed objects
            Bind<DefaultStatisticsProxyImpl>()
                .ToSelf()
                .WithConstructorArgument("configKey", _endpointConfigKey);
            
            Bind<IStatisticsProxyService>()
                .To<DefaultStatisticsProxyImpl>()
                .WithConstructorArgument("configKey", _endpointConfigKey);

            Bind<IIndicatorDAO>()
                .To<IndicatorDAO>();

            Bind<IStatisticsRequestStrategy>()
                .To<StatisticsProviderServiceRequester>()
                .Named("request");           
            
            Bind<IStatisticsRequestStrategy>()
                .To<CachedStatisticsProviderRequester>()
                .Named("cached");

            Bind<IStatisticsProviderRequestFactory>()
                .To<StatisticsProviderRequestFactory>()
                .WithConstructorArgument("kernel", Kernel);
        }
    }
}