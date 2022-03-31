using System.Collections.Generic;


namespace First_API.Services.Repositories
{
    public interface IRepositoryMetrics<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}