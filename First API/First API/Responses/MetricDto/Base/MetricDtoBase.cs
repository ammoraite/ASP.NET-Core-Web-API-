

using System;

namespace First_API.Responses
{
    public class MetricDtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
