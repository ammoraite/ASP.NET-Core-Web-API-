﻿using AutoMapper;
using Core.Interfaces;
using First_API.Controllers.MetricControllers;
using First_API.DAL.RequestsModules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase, IMetricController
    {

        private readonly IRepositoryesBase repository;

        private readonly ILogger<NetworkMetricsController> logger;

        private readonly IMapper mapper;

        public readonly static string NameMetrics = "NetworkMetrics";

        private readonly ControllerBaseWorker controllerBaseWorker;


        public NetworkMetricsController(IRepositoryesBase repository, ILogger<NetworkMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetrics);
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в {NameMetrics}Controller");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RequestNetworkMetricCreate request)
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


