using MetricsMeneger.DAL.Modules;
using MetricsMeneger.Services.Repositories;

namespace MetricsMeneger.Controllers.MetricControllers.Base
{
    public interface ICpuMetricRepository : IRepositoryMetrics<CpuMetric> { }
    public interface IDotNetMetricRepository : IRepositoryMetrics<DotNetMetric> { }
    public interface IRumMetricRepository : IRepositoryMetrics<RumMetric> { }
    public interface IHddMetricRepository : IRepositoryMetrics<HddMetric> { }
    public interface INetWorkMetricRepository : IRepositoryMetrics<NetWorkMetric> { }
}
