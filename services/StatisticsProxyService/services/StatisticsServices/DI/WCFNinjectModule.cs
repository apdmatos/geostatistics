using DependencyInjection;
using StatisticsProxyServiceDefenitions.interfaces;
using StatisticsServices.RestService.parameters_parser;

namespace RestService.DI
{
    public class WCFNinjectModule : DependencyInjectionNinjectModule
    {
        public WCFNinjectModule() : base("db", "providerConfiguration") { }

        public override void Load()
        {
            base.Load();

            //Injects the constructors of all DI-ed objects
            Bind<IURLParametersParser>().To<URLParameterDefaultImpl>();
        }
    }
}