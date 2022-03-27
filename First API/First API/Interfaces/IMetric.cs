using System;

namespace First_API.Interfaces
{
    public interface IMetric
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
        public string Name { get; set; }
    }
}
