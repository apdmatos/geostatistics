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
using StatisticsProxyImpl.StatisticsManagement;

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

            BindServices();

            BindDAOs();
            
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

        private void BindServices()
        {
            Bind<DefaultStatisticsProxyImpl>()
                .ToSelf()
                .WithConstructorArgument("configKey", _endpointConfigKey);

            Bind<IStatisticsProxyService>()
                .To<DefaultStatisticsProxyImpl>()
                .WithConstructorArgument("configKey", _endpointConfigKey);

            Bind<IStatisticsIndicatorManagementService>()
                .To<StatisticsManagement>();

            Bind<IStatisticsThemesManagementService>()
                .To<StatisticsManagement>();

            Bind<IStatisticsProvidersManagementService>()
                .To<StatisticsManagement>();

            //Bind<IStatisticsIndicatorManagementService>()
            //    .To<IndicatorManagement>();
            
            //Bind<IStatisticsThemesManagementService>()
            //    .To<ThemesManagement>();

            //Bind<IStatisticsProvidersManagementService>()
            //    .To<ProviderManagement>();
        }

        private void BindDAOs()
        {
            Bind<IIndicatorDAO>()
                .To<IndicatorDAO>();

            Bind<IProviderDAO>()
                .To<ProviderDAO>();

            Bind<IThemesDAO>()
                .To<ThemesDAO>();

            Bind<IConfigurationDAO>()
                .To<ConfigurationDAO>();

            Bind<IShapefileDAO>()
                .To<ShapefileDAO>();
        }
    }
}