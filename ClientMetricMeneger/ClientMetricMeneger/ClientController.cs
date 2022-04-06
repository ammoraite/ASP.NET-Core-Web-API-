using First_API.Client;
using Microsoft.AspNetCore.Mvc;

namespace First_API.Controllers
{
    public class ClientController : Controller
    {
        IMetricsAgentClient metricsAgentClient;

        public ClientController(IMetricsAgentClient metricsAgentClient)
        {
            this.metricsAgentClient = metricsAgentClient;
        }
    }
}
