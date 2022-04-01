using System.Collections.Generic;

namespace First_API.Interfaces
{
    public interface IAllMetricsResponse<T>
    {
        public List<T> Metrics { get; set; }
    }
}
