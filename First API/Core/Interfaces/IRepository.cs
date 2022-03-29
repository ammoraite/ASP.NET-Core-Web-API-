using System.Collections.Generic;

namespace First_API.Interfaces
{
    public interface IRepository <T>
    {
        IList<T> GetAll(string nameMetric);
        IMetric GetById(int id, string NameMetric);
        void Create(IMetric item,string nameMetric);
        void Update(IMetric item, string NameMetric);
        void Delete(int id, string NameMetric);
    }
}