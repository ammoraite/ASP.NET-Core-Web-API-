using AutoMapper;
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
    public class RumMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<RumMetricsController> _rumLogger;

        private readonly ControllerBaseWorker<RumMetric> _ramControllerBaseWorker;

        public RumMetricsController(IRumMetricRepository repository,
                                    ILogger<RumMetricsController> logger, 
                                    IMapper mapper)
        {
            _ramControllerBaseWorker = new ControllerBaseWorker<RumMetric>(repository, mapper, logger);
            this._rumLogger = logger;
            logger.LogDebug(1, $"NLog встроен в RumMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] RumRequestMetricCreate request)
        {
            _ramControllerBaseWorker.AddMetricFromRequest(request, new RumMetric());
            _rumLogger.LogDebug(1, $"Добавлена RumMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _rumLogger.LogDebug(1, $"Отправлены все RumMetric");
            return Ok(_ramControllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetRumMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(_ramControllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }
}


