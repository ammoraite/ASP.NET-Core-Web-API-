using System.Collections.Generic;

namespace First_API.Interfaces
{
    public interface IListMetricsResponse<T>
    {
        public List<T> Metrics { get; set; }
    }
}
