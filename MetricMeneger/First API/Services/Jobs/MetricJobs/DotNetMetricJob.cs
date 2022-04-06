using MetricsMeneger.Controllers.MetricControllers.Base;
using MetricsMeneger.DAL.Modules;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricRepository _repository;
        private PerformanceCounter _dotNetCounter;

        public DotNetMetricJob(IDotNetMetricRepository repository)
        {
            _repository = repository;
            _dotNetCounter = new PerformanceCounter(".NET CLR Security",
                                                    "Total Runtime Checks",
                                                    "_Global_");
        }

        public Task Execute(IJobExecutionContext context)
        {

            var totalruntimehecks = Convert.ToInt32(_dotNetCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
                TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new DotNetMetric()
            {
                Time = time,
                Value = totalruntimehecks
            });
            return Task.CompletedTask;
        }
    }

}
