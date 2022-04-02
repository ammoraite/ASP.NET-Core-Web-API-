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
    public class NetWorkMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<NetWorkMetricsController> logger;

        private readonly ControllerBaseWorker<NetWorkMetric> controllerBaseWorker;

        public NetWorkMetricsController(INetWorkMetricRepository repository, ILogger<NetWorkMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker<NetWorkMetric>(repository, mapper, logger);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в NetWorkMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] NetWorkRequestMetricCreate request)
        {
            NetWorkMetric NetWorkMetric = new NetWorkMetric();
            controllerBaseWorker.AddMetricFromRequest(request, NetWorkMetric);
            logger.LogDebug(1, $"Добавлена NetWorkMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все NetWorkMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetWorkMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(controllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


