using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using Quartz;
using System;
using System.Diagnostics;
using System.Linq;
using First_API.Controllers.MetricControllers.Base;
using Quartz;
using System.Threading.Tasks;
using First_API.DAL.Modules;

namespace MetricsAgent.Jobs
{
    public class NetWorkMetricJob : IJob
    {
        private INetWorkMetricRepository _repository;
        private PerformanceCounter _netWorkCounter;
        public NetWorkMetricJob(INetWorkMetricRepository repository)
        {
            _repository = repository;
            _netWorkCounter = new PerformanceCounter("Network Interface",
                                                    "Bytes Total/sec",
                                                    "Realtek PCIe Gbe Family Controller");
                                                            
            
        }
        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_netWorkCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
                TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new NetWorkMetric()
            {
                Time = time,
                Value = cpuUsageInPercents
            });
            return Task.CompletedTask;
        }
    }
}
