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
    public class DotNetMetricsController : ControllerBase, IMetricController
    {

        

        private readonly ILogger<DotNetMetricsController> logger;

        

        private readonly ControllerBaseWorker controllerBaseWorker;

        private const string NameMetric = "DotNetMetric";

        public DotNetMetricsController(IRepositoryMetrics<Metric> repository, ILogger<DotNetMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetric);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в DotNetMetricController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetRequestMetricCreate request)
        {

            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена DotNetMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все DotNetMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
    }
}





