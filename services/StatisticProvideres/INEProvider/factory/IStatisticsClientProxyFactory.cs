using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INEProvider.factory
{
    public interface IStatisticsClientProxyFactory
    {
        INEProvider.INEService.StatisticsClient CreateStatisticsClient();
    }
}
