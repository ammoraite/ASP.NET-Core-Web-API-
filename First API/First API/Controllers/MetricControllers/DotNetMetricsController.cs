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
    public class DotNetMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<DotNetMetricsController> _dotnetLogger;

        private readonly ControllerBaseWorker<DotNetMetric> _dotnetControllerBaseWorker;

        public DotNetMetricsController(IDotNetMetricRepository repository, 
                                       ILogger<DotNetMetricsController> logger, 
                                       IMapper mapper)
        {
            _dotnetControllerBaseWorker = new ControllerBaseWorker<DotNetMetric>(repository, mapper, logger);
            this._dotnetLogger = logger;
            logger.LogDebug(1, $"NLog встроен в DotNetMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetRequestMetricCreate request)
        {
            _dotnetControllerBaseWorker.AddMetricFromRequest(request, new DotNetMetric());
            _dotnetLogger.LogDebug(1, $"Добавлена DotNetMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _dotnetLogger.LogDebug(1, $"Отправлены все DotNetMetric");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetDotNetMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(_dotnetControllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


