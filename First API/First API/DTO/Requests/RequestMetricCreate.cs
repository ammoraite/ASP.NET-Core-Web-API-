using First_API.Interfaces;
using System;

namespace First_API.Requests
{
    public class RequestMetricCreate:IMetricCreateRequest
    {
        
        public int Time { get; set; }
        public int Value { get; set; }
    }
}
