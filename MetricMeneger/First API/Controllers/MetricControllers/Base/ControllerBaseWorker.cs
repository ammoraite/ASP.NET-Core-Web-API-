using AutoMapper;
using MetricsMeneger.DAL.BaseModuls;
using MetricsMeneger.Interfaces;
using MetricsMeneger.Responses;
using MetricsMeneger.Services.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsMeneger.Controllers.MetricControllers
{
    public class ControllerBaseWorker<T> where T : IMetric
    {
        private IRepositoryMetrics<T> repository;
        private readonly IMapper mapper;



        public ControllerBaseWorker(
                IRepositoryMetrics<T> repository,
                IMapper mapper,
                ILogger<IMetricController> logger)
        {
            this.repository = repository; ;
            this.mapper = mapper;
        }
        public void AddMetricFromRequest(IMetricCreateRequest request, T item)
        {
            item.Value = request.Value;
            item.Time = TimeSpan.FromSeconds(request.Time);
            repository.Create(item);
        }


        public ResponseAllMetrics GetAllmetric()
        {
            var response = new ResponseAllMetrics()
            {
                Metrics = new List<DtoMetric>()
            };
            foreach (var metric in repository.GetAll())
            {
                response.Metrics.Add(mapper.Map<DtoMetric>(metric));
            }
            return response;
        }


        internal ResponseAllMetrics GetAllmetricToTime(TimeSpan fromTime, TimeSpan toTime)
        {
            var response = new ResponseAllMetrics()
            {
                Metrics = new List<DtoMetric>()
            };

            foreach (var metric in repository.GetAll())
            {
                if (metric.Time <= fromTime || metric.Time >= toTime)
                {
                    response.Metrics.Add(mapper.Map<DtoMetric>(metric));
                }
            }
            return response;
        }
    }
}
