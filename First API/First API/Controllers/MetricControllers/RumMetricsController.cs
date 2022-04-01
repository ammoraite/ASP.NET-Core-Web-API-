using System;
using AutoMapper;
using First_API.Controllers.MetricControllers;
using First_API.Controllers.MetricControllers.Base;
using First_API.DAL.Modules;
using First_API.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RumMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<RumMetricsController> logger;

        private readonly ControllerBaseWorker<RumMetric> controllerBaseWorker;

        public RumMetricsController(IRumMetricRepository repository, ILogger<RumMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker<RumMetric>(repository, mapper, logger);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в RumMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] RumRequestMetricCreate request)
        {
            RumMetric RumMetric = new RumMetric();
            controllerBaseWorker.AddMetricFromRequest(request, RumMetric);
            logger.LogDebug(1, $"Добавлена RumMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все RumMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetRumMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(controllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }
}


