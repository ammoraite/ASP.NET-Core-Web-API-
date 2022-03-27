

using First_API.Interfaces;
using System;

namespace First_API.DAL.BaseModuls
{
    public class MetricBase:IMetric
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
       
    }
}
