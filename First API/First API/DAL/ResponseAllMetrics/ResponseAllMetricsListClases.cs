
using First_API.DAL.MetricDtoModules;
using First_API.Interfaces;
using System.Collections.Generic;

namespace First_API.Responses
{
    public class ResponseAllCpuMetrics: ResponseAllMetricsBase { }
    public class ResponseAllDotNetMetrics : ResponseAllMetricsBase { }
    public class ResponseAllNetworkMetrics : ResponseAllMetricsBase { }
    public class ResponseAllRamMetrics : ResponseAllMetricsBase { }
    public class ResponseAllHddMetrics : ResponseAllMetricsBase { }

}
