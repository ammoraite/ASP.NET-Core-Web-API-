using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using First_API.Services.Migrations;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteDotNetREpository : IDotNetMetricRepository
    {
        private const string ConnectionString = "Data Source=HardWareMetrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<DotNetMetric> repositoryWorker;
        public SqlLiteDotNetREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            repositoryWorker = new RepositoryMetricWorker<DotNetMetric>(ConnectionString,
                DotNetMetricsMigration.NameTableMetric);
        }
        public IList<DotNetMetric> GetAll()
        {
            return repositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            repositoryWorker.Delete(id);
        }
        public void Update(DotNetMetric item)
        {
            repositoryWorker.Update(item);
        }
        public DotNetMetric GetById(int id)
        {
            return repositoryWorker.GetById(id);
        }

        public void Create(DotNetMetric item)
        {
            repositoryWorker.Create(item);
        }


    }
}
