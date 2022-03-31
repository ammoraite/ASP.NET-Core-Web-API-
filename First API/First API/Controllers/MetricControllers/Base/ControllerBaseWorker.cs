using AutoMapper;
using First_API.DAL.BaseModuls;
using First_API.Interfaces;
using First_API.Requests;
using First_API.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using First_API.Services.Repositories;

namespace First_API.Controllers.MetricControllers
{
    public class ControllerBaseWorker
    {
        private IRepositoryMetrics<Metric> repository;
        private readonly IMapper mapper;

        private readonly string _nameMetricFromController;

        public ControllerBaseWorker(
                IRepositoryMetrics<Metric> repository,
                IMapper mapper,
                ILogger<IMetricController> logger,string nameMetricFromController)
        {
            this.repository = repository;
            _nameMetricFromController = nameMetricFromController;
            this.mapper = mapper;
        }
        public void AddMetricFromRequest(IMetricCreateRequest request)
        {

            Metric Mb =new()
            {
                Time = TimeSpan.FromSeconds(request.Time),
                Value = request.Value,
                Name = _nameMetricFromController
            };

            repository.Create(Mb);

        }


        public ResponseAllMetrics GetAllmetric()
        {
           
          

            var response = new ResponseAllMetrics()
            {
                Metrics = new List<DtoMetric>()
            };
            foreach (var metric in repository.GetAll().Where(n => n.Name == _nameMetricFromController))
            {
                response.Metrics.Add(mapper.Map<DtoMetric>(metric));

            }
            return response;
        }

    }
}
