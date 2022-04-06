using MetricsMeneger.Interfaces;
using System;

namespace MetricsMeneger.DAL.BaseModuls
{
    public class Metric : IMetric
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }

    }
}
