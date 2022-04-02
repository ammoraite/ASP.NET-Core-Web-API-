using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using First_API.Services.Migrations;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteRumREpository : IRumMetricRepository
    {
        private const string ConnectionString = "Data Source=HardWareMetrics.db;Version=3;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<RumMetric> repositoryWorker;
        public SqlLiteRumREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            repositoryWorker = new RepositoryMetricWorker<RumMetric>(ConnectionString,
                "RumMetric");
        }
        public IList<RumMetric> GetAll()
        {
            return repositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            repositoryWorker.Delete(id);
        }
        public void Update(RumMetric item)
        {
            repositoryWorker.Update(item);
        }
        public RumMetric GetById(int id)
        {
            return repositoryWorker.GetById(id);
        }

        public void Create(RumMetric item)
        {
            repositoryWorker.Create(item);
        }


    }
}
