using System;
using System.Diagnostics;
using First_API.Controllers.MetricControllers.Base;
using Quartz;
using System.Threading.Tasks;
using First_API.DAL.Modules;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricRepository _repository;
        private PerformanceCounter _hddCounter;
        public HddMetricJob(IHddMetricRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("PhysicalDisk", "Avg. Disk Bytes/Read", "_Total");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_hddCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
                TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new HddMetric
            {
                Time = time,
                Value = cpuUsageInPercents
            });
            return Task.CompletedTask;
        }
    }

}