using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsProxyImpl.requesters;

namespace StatisticsProxyImpl.factories
{
    public interface IStatisticsProviderRequestFactory
    {
        IStatisticsRequestStrategy GetStatisticRequestStrategy(string serviceEndpoint, string configurationKey);
    }
}
