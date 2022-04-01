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
    public class DotNetMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<DotNetMetricsController> logger;

        private readonly ControllerBaseWorker<DotNetMetric> controllerBaseWorker;

        public DotNetMetricsController(IDotNetMetricRepository repository, ILogger<DotNetMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker<DotNetMetric>(repository, mapper, logger);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в DotNetMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetRequestMetricCreate request)
        {
            DotNetMetric DotNetMetric = new DotNetMetric();
            controllerBaseWorker.AddMetricFromRequest(request, DotNetMetric);
            logger.LogDebug(1, $"Добавлена DotNetMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все DotNetMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetDotNetMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(controllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


