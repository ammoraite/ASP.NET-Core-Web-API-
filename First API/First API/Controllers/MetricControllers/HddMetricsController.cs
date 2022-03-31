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
    public class HddMetricsController : ControllerBase, IMetricController
    {
        private readonly ILogger<HddMetricsController> logger;

        private readonly ControllerBaseWorker controllerBaseWorker;

        private const string NameMetric = "HddNetMetric";

        public HddMetricsController(IRepositoryMetrics<Metric> repository, ILogger<HddMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetric);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в HddMetricController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddRequestMetricCreate request)
        {

            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена HddMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все HddMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
    }
}