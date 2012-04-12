using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using INEProvider.INEService;
using Ninject;
using INEProvider.request;
using INEProvider.Aggregator;

namespace INEProvider.DI
{
    public class WCFNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Injects the constructors of all DI-ed objects
            Bind<StatisticsClient>().ToSelf();
            Bind<IKernel>().ToConstant(Kernel);
            Bind<IINERequesterWrapper>().To<INERequestWrapper>().InRequestScope();
            Bind<IAggregator>().To<DefaultAggregatorImpl>().InSingletonScope();
        }
    }
}