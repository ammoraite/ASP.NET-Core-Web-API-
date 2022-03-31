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
    public class RamMetricsController : ControllerBase, IMetricController
    {
        private readonly ILogger<RamMetricsController> logger;

        private readonly ControllerBaseWorker controllerBaseWorker;

        private const string NameMetric = "RamMetric";

        public RamMetricsController(IRepositoryMetrics<Metric> repository, ILogger<RamMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetric);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в vMetricController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamRequestMetricCreate request)
        {

            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена RamMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все RamMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
    }
}