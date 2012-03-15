using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace INEProvider.factory
{
    public class StatisticsClientProxyFactory : IStatisticsClientProxyFactory
    {
        private IKernel _kernel;
        public StatisticsClientProxyFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public INEService.StatisticsClient CreateStatisticsClient()
        {
            return _kernel.Get<INEProvider.INEService.StatisticsClient>();
        }
    }
}