using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using First_API.Services.Migrations;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteCpuREpository : ICpuMetricRepository
    {
        private const string ConnectionString = @"Data Source=HardWareMetrics.db;Version=3;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<CpuMetric> repositoryWorker;
        public SqlLiteCpuREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            repositoryWorker = new RepositoryMetricWorker<CpuMetric>(ConnectionString,
                CpuMetricsMigration.NameTableMetric);
        }
        public IList<CpuMetric> GetAll()
        {
            return repositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            repositoryWorker.Delete(id);
        }
        public void Update(CpuMetric item)
        {
            repositoryWorker.Update(item);
        }
        public CpuMetric GetById(int id)
        {
            return repositoryWorker.GetById(id);
        }

        public void Create(CpuMetric item)
        {
            repositoryWorker.Create(item);
        }


    }
}
