using AutoMapper;
using Core.Interfaces;
using First_API.Controllers.MetricControllers;
using First_API.DAL.RequestsModules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsController : ControllerBase, IMetricController
    {

        private readonly IRepositoryesBase repository;

        private readonly ILogger<HddMetricsController> logger;

        private readonly IMapper mapper;

        public readonly static string NameMetrics = "HddMetrics";

        private readonly ControllerBaseWorker controllerBaseWorker;


        public HddMetricsController(IRepositoryesBase repository, ILogger<HddMetricsController> logger, IMapper mapper)
        {
            controllerBaseWorker = new ControllerBaseWorker(repository, mapper, logger, NameMetrics);
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
            logger.LogDebug(1, $"NLog встроен в {NameMetrics}Controller");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RequestHddMetricCreate request)
        {
            controllerBaseWorker.AddMetricFromRequest(request);
            logger.LogDebug(1, $"Добавлена CpuMetric: {request.Name}");
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            logger.LogDebug(1, $"Отправлены все CpuMetric в {NameMetrics}");
            return Ok(controllerBaseWorker.GetAllmetric());
        }
    }
}


