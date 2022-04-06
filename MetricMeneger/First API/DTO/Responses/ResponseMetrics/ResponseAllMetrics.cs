using MetricsMeneger.DAL.BaseModuls;
using MetricsMeneger.Interfaces;
using System.Collections.Generic;

namespace MetricsMeneger.Responses
{
    public class ResponseAllMetrics : IListMetricsResponse<DtoMetric>
    {
        public List<DtoMetric> Metrics { get; set; }
    }

}
