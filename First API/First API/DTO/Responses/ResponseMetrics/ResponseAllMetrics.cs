﻿using First_API.DAL.BaseModuls;
using First_API.Interfaces;
using System.Collections.Generic;

namespace First_API.Responses
{
    public class ResponseAllMetrics : IListMetricsResponse<DtoMetric>
    {
        public List<DtoMetric> Metrics { get; set; }
    }

}
