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
    public class CpuMetricsController : ControllerBase, IMetricController
    {

        private readonly ILogger<CpuMetricsController> logger;

        private readonly ControllerBaseWorker controllerBaseWorker;

        private const string NameMetric = "CpuMetric";

       

        public CpuMetricsController(IRepositoryMetrics<Metric> repository, ILogger<CpuMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetric);
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в CpuMetricController");
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuRequestMetricCreate request)
        {

            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена CpuMetric");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все CpuMetric");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
    }
}


