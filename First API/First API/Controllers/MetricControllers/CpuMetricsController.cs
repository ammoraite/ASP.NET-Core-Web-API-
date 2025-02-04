﻿using AutoMapper;
using First_API.Controllers.MetricControllers;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<CpuMetricsController> _cpuLogger;

        private readonly ControllerBaseWorker<CpuMetric> _cpuControllerBaseWorker;

        public CpuMetricsController(ICpuMetricRepository repository, 
                                    ILogger<CpuMetricsController> logger,
                                    IMapper mapper)
        {
            _cpuControllerBaseWorker = new ControllerBaseWorker<CpuMetric>(repository, mapper, logger);
            _cpuLogger = logger;
            logger.LogDebug(1, $"NLog встроен в CpuMetricController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuRequestMetricCreate request)
        {
            _cpuControllerBaseWorker.AddMetricFromRequest(request, new CpuMetric());
            _cpuLogger.LogDebug(1, $"Добавлена CpuMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _cpuLogger.LogDebug(1, $"Отправлены все CpuMetric");
            return Ok(_cpuControllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetricsFromAllCluster
                (
                [FromRoute] TimeSpan fromTime,
                [FromRoute] TimeSpan toTime
                )
        {
            return Ok(_cpuControllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


