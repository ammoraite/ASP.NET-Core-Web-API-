using AutoMapper;
using MetricsMeneger.Controllers.MetricControllers;
using MetricsMeneger.Controllers.MetricControllers.Base;
using MetricsMeneger.DAL.Modules;
using MetricsMeneger.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsMeneger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<HddMetricsController> _hddLogger;

        private readonly ControllerBaseWorker<HddMetric> _hddControllerBaseWorker;

        public HddMetricsController(IHddMetricRepository repository, 
                                    ILogger<HddMetricsController> logger, 
                                    IMapper mapper)
        {
            _hddControllerBaseWorker = new ControllerBaseWorker<HddMetric>(repository, mapper, logger);
            _hddLogger = logger;
            logger.LogDebug(1, $"NLog встроен в HddMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] HddRequestMetricCreate request)
        {
            _hddControllerBaseWorker.AddMetricFromRequest(request, new HddMetric());
            _hddLogger.LogDebug(1, $"Добавлена HddMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _hddLogger.LogDebug(1, $"Отправлены все HddMetric");
            return Ok(_hddControllerBaseWorker.GetAllmetric());
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetHddMetricsFromAllCluster
        (
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok(_hddControllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


