using RestService.parameters_parser;
using DependencyInjection;
using StatisticsProxyServiceDefenitions.interfaces;

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