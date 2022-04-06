using First_API.DTO.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;

namespace First_API.Client
{
    public class MetricsAgentClient : IMetricsAgentClient

    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public MetricsAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request)
        {
            var fromParameter = request.FromTime.TotalSeconds;
            var datanow = DateTime.Now;
            var toParameter =

            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{request.ClientBaseAddress}/api/hddmetrics/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream =
                    response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        //public AllRumMetricsApiResponse GetAllRamMetrics(GetAllRumMetricsApiRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public AllDotNetMetricsApiResponse GetDonNetMetrics(GetAllDotNetMetricsApiRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
    // остальные методы реализовать самим
}


