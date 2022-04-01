using First_API.DAL.Modules;
using First_API.Services.Repositories;

namespace First_API.Controllers.MetricControllers.Base
{
    public interface ICpuMetricRepository : IRepositoryMetrics<CpuMetric>
    {
    }
    public interface IDotNetMetricRepository : IRepositoryMetrics<DotNetMetric>
    {
    }
    public interface IRumMetricRepository : IRepositoryMetrics<RumMetric>
    {
    }
    public interface IHddMetricRepository : IRepositoryMetrics<HddMetric>
    {
    }
    public interface INetWorkMetricRepository : IRepositoryMetrics<NetWorkMetric>
    {
    }
}
