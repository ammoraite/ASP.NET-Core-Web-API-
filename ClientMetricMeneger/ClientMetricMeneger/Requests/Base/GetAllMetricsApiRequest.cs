using System;

namespace First_API.Requests
{
    public class GetAllMetricsApiRequest
    {
        public TimeSpan FromTime { get;  set; }
        public TimeSpan ToTime { get; set; }
        public Uri ClientBaseAddress { get; set; }
    }
}