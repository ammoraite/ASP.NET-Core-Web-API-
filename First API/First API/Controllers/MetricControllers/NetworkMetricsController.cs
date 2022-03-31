using AutoMapper;
using First_API.Controllers.MetricControllers;
using First_API.DAL.BaseModuls;
using First_API.DTO.Requests;
using First_API.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetWorkMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<NetWorkMetricsController> logger;

        private readonly ControllerBaseWorker controllerBaseWorker;

        private const string NameMetric = "NetWorkMetric";

        public NetWorkMetricsController(IRepositoryMetrics<Metric> repository, ILogger<NetWorkMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetric);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в NetWorkMetricController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] NetWorkRequestMetricCreate request)
        {

            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена NetWorkMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все NetWorkMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
    }
}