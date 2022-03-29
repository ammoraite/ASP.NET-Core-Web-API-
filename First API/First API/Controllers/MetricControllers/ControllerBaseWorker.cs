using AutoMapper;
using Core.Interfaces;
using First_API.DAL.BaseModuls;
using First_API.Interfaces;
using First_API.Requests;
using First_API.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace First_API.Controllers.MetricControllers
{
    public class ControllerBaseWorker
    {
        private IRepositoryesBase repository;

        private IMapper mapper;

        private ILogger<IMetricController> logger;
        public string NameMetrics { get; set; }

        public ControllerBaseWorker (
                IRepositoryesBase repository,
                IMapper mapper,
                ILogger<IMetricController> logger,
                string NameMetrics)
            { 
                this.repository = repository;
                this.mapper = mapper;
                this.logger = logger;
                this.NameMetrics = NameMetrics;
        }
        public void AddMetricFromRequest(MetricCreateRequestBase request)
        {
            repository.Create(new MetricBase
            {
                Time = TimeSpan.FromSeconds(request.Time),
                Value = request.Value,
                Name = NameMetrics
            }, NameMetrics);
        }

        

        public ResponseAllMetricsBase GetAllmetric()
        {
            var metrics = repository.GetAll(NameMetrics);

            var response = new ResponseAllMetricsBase()
            {
                Metrics = new List<MetricBase>()
            };

            foreach (var metric in metrics)
            {              
                response.Metrics.Add(metric);
            }
            logger.LogDebug(1, $"Отправлены все CpuMetric в {NameMetrics}");
            return response;
        }

    }
}
