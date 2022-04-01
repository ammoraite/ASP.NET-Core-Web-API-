using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using First_API.Services.Migrations;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteHddREpository : IHddMetricRepository
    {
        private const string ConnectionString = "Data Source=HardWareMetrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<HddMetric> repositoryWorker;
        public SqlLiteHddREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            repositoryWorker = new RepositoryMetricWorker<HddMetric>(ConnectionString,
                HddMetricsMigration.NameTableMetric);
        }
        public IList<HddMetric> GetAll()
        {
            return repositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            repositoryWorker.Delete(id);
        }
        public void Update(HddMetric item)
        {
            repositoryWorker.Update(item);
        }
        public HddMetric GetById(int id)
        {
            return repositoryWorker.GetById(id);
        }

        public void Create(HddMetric item)
        {
            repositoryWorker.Create(item);
        }


    }
}
