using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsProxyImpl.factories;
using StatisticsProxyImpl.requesters;
using Ninject;
using Ninject.Parameters;

namespace DependencyInjection.factories
{
    class StatisticsProviderRequestFactory : IStatisticsProviderRequestFactory
    {
        private IKernel _kernel;

        public StatisticsProviderRequestFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IStatisticsRequestStrategy GetStatisticRequestStrategy(string serviceEndpoint, string configurationKey)
        {
            var request = _kernel.Get<IStatisticsRequestStrategy>("request",
                new ConstructorArgument("endpoint", serviceEndpoint),
                new ConstructorArgument("configurationKey", configurationKey));

            return _kernel.Get<IStatisticsRequestStrategy>("cached", 
                new ConstructorArgument("requester", request));
        }
    }
}
