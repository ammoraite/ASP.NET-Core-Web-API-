using Dapper;
using MetricsMeneger.Controllers.MetricControllers.Base;
using MetricsMeneger.DAL.Modules;
using MetricsMeneger.Handlers;
using System.Collections.Generic;

namespace MetricsMeneger.Services.Repositories
{

    public class SqlLiteHddREpository : IHddMetricRepository
    {
        private const string HddRepConnectionString = "Data Source=MenegerHardWareMetrics.db;Version=3;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<HddMetric> _hddrepositoryWorker;
        public SqlLiteHddREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _hddrepositoryWorker = new RepositoryMetricWorker<HddMetric>(HddRepConnectionString,
                "HddMetric");
        }
        public IList<HddMetric> GetAll()
        {
            return _hddrepositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            _hddrepositoryWorker.Delete(id);
        }
        public void Update(HddMetric item)
        {
            _hddrepositoryWorker.Update(item);
        }
        public HddMetric GetById(int id)
        {
            return _hddrepositoryWorker.GetById(id);
        }

        public void Create(HddMetric item)
        {
            _hddrepositoryWorker.Create(item);
        }


    }
}
