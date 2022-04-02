using System;
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
    public class HddMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<HddMetricsController> logger;

        private readonly ControllerBaseWorker<HddMetric> controllerBaseWorker;

        public HddMetricsController(IHddMetricRepository repository, ILogger<HddMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker<HddMetric>(repository, mapper, logger);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в HddMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] HddRequestMetricCreate request)
        {
            HddMetric HddMetric = new HddMetric();
            controllerBaseWorker.AddMetricFromRequest(request, HddMetric);
            logger.LogDebug(1, $"Добавлена HddMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все HddMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetHddMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(controllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


