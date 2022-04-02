using Dapper;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.Handlers;
using System.Collections.Generic;

namespace First_API.Services.Repositories
{

    public class SqlLiteCpuREpository : ICpuMetricRepository
    {
        private const string CpuRepConnectionString = @"Data Source=HardWareMetrics.db;Version=3;";
       
        private readonly RepositoryMetricWorker<CpuMetric> _cpuRepositoryWorker;
        public SqlLiteCpuREpository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _cpuRepositoryWorker = new RepositoryMetricWorker<CpuMetric>(CpuRepConnectionString,
                "CpuMetric");
        }
        public IList<CpuMetric> GetAll()
        {
            return _cpuRepositoryWorker.GetAll();
        }
        public void Delete(int id)
        {
            _cpuRepositoryWorker.Delete(id);
        }
        public void Update(CpuMetric item)
        {
            _cpuRepositoryWorker.Update(item);
        }
        public CpuMetric GetById(int id)
        {
            return _cpuRepositoryWorker.GetById(id);
        }

        public void Create(CpuMetric item)
        {
            _cpuRepositoryWorker.Create(item);
        }


    }
}
