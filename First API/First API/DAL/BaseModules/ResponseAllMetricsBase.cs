using First_API.DAL.BaseModuls;
using First_API.Interfaces;
using System;
using System.Collections.Generic;

namespace First_API.Responses
{
    public class ResponseAllMetricsBase : IAllMetricsResponse<MetricBase>
    {
        public List<MetricBase> Metrics { get; set; }
    }

}
