using First_API.Interfaces;
using System.Collections.Generic;

namespace First_API.Responses
{
    public class AllBaseMetricsResponse<T> where T : IMetricDto
    {
        public List<T> Metrics { get; set; } 
    }
    
}
