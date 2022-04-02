using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteDotNetREpository : IDotNetMetricRepository
    {
        private const string DotnetRepConnectionString = "Data Source=HardWareMetrics.db;Version=3;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<DotNetMetric> _dotnetRepositoryWorker;
        public SqlLiteDotNetREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _dotnetRepositoryWorker = new RepositoryMetricWorker<DotNetMetric>(DotnetRepConnectionString,
                "DotNetMetric");
        }
        public IList<DotNetMetric> GetAll()
        {
            return _dotnetRepositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            _dotnetRepositoryWorker.Delete(id);
        }
        public void Update(DotNetMetric item)
        {
            _dotnetRepositoryWorker.Update(item);
        }
        public DotNetMetric GetById(int id)
        {
            return _dotnetRepositoryWorker.GetById(id);
        }

        public void Create(DotNetMetric item)
        {
            _dotnetRepositoryWorker.Create(item);
        }


    }
}
