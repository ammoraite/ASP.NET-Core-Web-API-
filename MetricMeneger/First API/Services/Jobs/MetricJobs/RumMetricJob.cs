using MetricsMeneger.Controllers.MetricControllers.Base;
using MetricsMeneger.DAL.Modules;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class RumMetricJob : IJob
    {
        private IRumMetricRepository _repository;
        private PerformanceCounter _rumCounter;
        public RumMetricJob(IRumMetricRepository repository)
        {
            _rumCounter = new PerformanceCounter("NUMA Node Memory",
                                                 "Available MBytes",
                                                 "_Total");
            _repository = repository;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var rumAvailableMBytes = Convert.ToInt32(_rumCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
                TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new RumMetric()
            {
                Time = time,
                Value = rumAvailableMBytes
            });
            return Task.CompletedTask;
        }
    }
}
