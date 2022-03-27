using System;

namespace First_API.Interfaces
{
    public interface IMetricDto
    {
        public TimeSpan Time { get; set; }
        public  int Value { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
