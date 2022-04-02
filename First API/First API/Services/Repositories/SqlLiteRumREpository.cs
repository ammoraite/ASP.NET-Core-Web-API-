using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteRumREpository : IRumMetricRepository
    {
        private const string RumRepConnectionString = "Data Source=HardWareMetrics.db;Version=3;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<RumMetric> _rumRepositoryWorker;
        public SqlLiteRumREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _rumRepositoryWorker = new RepositoryMetricWorker<RumMetric>(RumRepConnectionString,
                "RumMetric");
        }
        public IList<RumMetric> GetAll()
        {
            return _rumRepositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            _rumRepositoryWorker.Delete(id);
        }
        public void Update(RumMetric item)
        {
            _rumRepositoryWorker.Update(item);
        }
        public RumMetric GetById(int id)
        {
            return _rumRepositoryWorker.GetById(id);
        }

        public void Create(RumMetric item)
        {
            _rumRepositoryWorker.Create(item);
        }


    }
}
