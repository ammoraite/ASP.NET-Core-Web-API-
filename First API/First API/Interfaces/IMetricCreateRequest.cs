using System;

namespace First_API.Interfaces
{
    public interface IMetricCreateRequest
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public int Value { get; set; }
    }
}
