using System;
using System.Diagnostics;
using First_API.Controllers.MetricControllers.Base;
using Quartz;
using System.Threading.Tasks;
using First_API.DAL.Modules;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricRepository _repository;
        private PerformanceCounter _dotNetCounter;
        public DotNetMetricJob(IDotNetMetricRepository repository)
        {
            _repository = repository;
            _dotNetCounter = new PerformanceCounter(".NET CLR Security", "Total Runtime Checks", "_Global_");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_dotNetCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
                TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new DotNetMetric()
            {
                Time = time,
                Value = cpuUsageInPercents
            });
            return Task.CompletedTask;
        }
    }
    
}
