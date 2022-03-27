using AutoMapper;
using Core.Interfaces;
using First_API.Controllers.MetricControllers;
using First_API.DAL.BaseModuls;
using First_API.DAL.MetricDtoModules;
using First_API.DAL.MetricsModules;
using First_API.DAL.RequestsModules;
using First_API.Interfaces;
using First_API.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricsController : ControllerBase,IMetricController
    {

        private readonly IRepositoryesBase repository;

        private readonly ILogger<CpuMetricsController> logger;

        private readonly IMapper mapper;

        public readonly static string NameMetrics= "CpuMetrics";

        private readonly ControllerBaseWorker controllerBaseWorker;


        public CpuMetricsController(IRepositoryesBase repository, ILogger<CpuMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetrics);
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в {NameMetrics}Controller");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RequestCpuMetricCreate request)
        {
            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена CpuMetric: {request.Name}");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все CpuMetric в {NameMetrics}");
            return Ok(controllerBaseWorker.GetAllmetric());
        }        
    }
}


