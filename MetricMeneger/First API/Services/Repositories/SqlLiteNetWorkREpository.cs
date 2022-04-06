using Dapper;
using MetricsMeneger.Controllers.MetricControllers.Base;
using MetricsMeneger.DAL.Modules;
using MetricsMeneger.Handlers;
using System.Collections.Generic;

namespace MetricsMeneger.Services.Repositories
{

    public class SqlLiteNetWorkREpository : INetWorkMetricRepository
    {
        private const string NetWorkRepConnectionString = "Data Source=MenegerHardWareMetrics.db;Version=3;";
        // Инжектируем соединение с базой данных в наш репозиторий через конструктор
        private RepositoryMetricWorker<NetWorkMetric> _networkRepositoryWorker;
        public SqlLiteNetWorkREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _networkRepositoryWorker = new RepositoryMetricWorker<NetWorkMetric>(NetWorkRepConnectionString,
                "NetWorkMetric");
        }
        public IList<NetWorkMetric> GetAll()
        {
            return _networkRepositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            _networkRepositoryWorker.Delete(id);
        }
        public void Update(NetWorkMetric item)
        {
            _networkRepositoryWorker.Update(item);
        }
        public NetWorkMetric GetById(int id)
        {
            return _networkRepositoryWorker.GetById(id);
        }

        public void Create(NetWorkMetric item)
        {
            _networkRepositoryWorker.Create(item);
        }


    }
}
