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

        private readonly ILogger<NetWorkMetricsController> _networkLogger;

        private readonly ControllerBaseWorker<NetWorkMetric> _networkControllerBaseWorker;

        public NetWorkMetricsController(INetWorkMetricRepository repository,
                                        ILogger<NetWorkMetricsController> logger, 
                                        IMapper mapper)
        {
            _networkControllerBaseWorker = new ControllerBaseWorker<NetWorkMetric>(repository, mapper, logger);
            _networkLogger = logger;
            logger.LogDebug(1, $"NLog встроен в NetWorkMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] NetWorkRequestMetricCreate request)
        {
            _networkControllerBaseWorker.AddMetricFromRequest(request, new NetWorkMetric());
            _networkLogger.LogDebug(1, $"Добавлена NetWorkMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _networkLogger.LogDebug(1, $"Отправлены все NetWorkMetric");
            return Ok(_networkControllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetWorkMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(_networkControllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


