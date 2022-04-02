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
    public class CpuMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<CpuMetricsController> logger;

        private readonly ControllerBaseWorker<CpuMetric> controllerBaseWorker;

        public CpuMetricsController(ICpuMetricRepository repository, ILogger<CpuMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker<CpuMetric>(repository, mapper, logger);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в CpuMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuRequestMetricCreate request)
        {
            CpuMetric cpuMetric = new CpuMetric();
            controllerBaseWorker.AddMetricFromRequest(request, cpuMetric);
            logger.LogDebug(1, $"Добавлена CpuMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все CpuMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetricsFromAllCluster
                (
                [FromRoute] TimeSpan fromTime,
                [FromRoute] TimeSpan toTime
                )
        {
            return Ok(controllerBaseWorker.GetAllmetricToTime(fromTime, toTime));
        }
    }


}


