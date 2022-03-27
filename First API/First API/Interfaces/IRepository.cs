using First_API.SQLmetricitem;
using System.Collections.Generic;

namespace First_API.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IList<MetricBase> GetAll(string nameMetric);
        MetricBase GetById(int id, string NameMetric);
        void Create(T item,string nameMetric);
        void Update(T item, string NameMetric);
        void Delete(int id, string NameMetric);
    }
}