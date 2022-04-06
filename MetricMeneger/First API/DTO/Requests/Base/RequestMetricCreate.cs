using MetricsMeneger.Interfaces;

namespace MetricsMeneger.Requests
{
    public class RequestMetricCreate : IMetricCreateRequest
    {
        public int Value { get; set; }

        public int Time { get; set; }
    }
}
