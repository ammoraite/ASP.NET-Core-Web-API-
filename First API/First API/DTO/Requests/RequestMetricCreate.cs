using First_API.Interfaces;

namespace First_API.Requests
{
    public class RequestMetricCreate : IMetricCreateRequest
    {
        public int Value { get; set; }

        public int Time { get; set; }
    }
}
