using First_API.Requests;

namespace First_API.DTO.Requests
{
    public class CpuRequestMetricCreate: RequestMetricCreate { private readonly string Name = "CpuMetric"; }
    public class DotNetRequestMetricCreate : RequestMetricCreate { private readonly string Name = "DotNetMetric"; }
    public class HddRequestMetricCreate : RequestMetricCreate { private readonly string Name = "HddNetMetric"; }
    public class NetWorkRequestMetricCreate : RequestMetricCreate { private readonly string Name = "NetworkMetric"; }
    public class RamRequestMetricCreate : RequestMetricCreate { private readonly string Name = "RamMetric"; }

}
