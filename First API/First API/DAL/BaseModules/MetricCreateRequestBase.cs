using First_API.Interfaces;
using System;

namespace First_API.Requests
{
    public class MetricCreateRequestBase:IMetricCreateRequest
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public int Value { get; set; }
    }
}
