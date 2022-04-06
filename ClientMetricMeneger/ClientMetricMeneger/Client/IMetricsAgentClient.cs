using First_API.DTO.Requests;

namespace First_API.Client
{
    public interface IMetricsAgentClient
    {
        AllRumMetricsApiResponse GetAllRamMetrics(GetAllRumMetricsApiRequest request);
        AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request);
        AllDotNetMetricsApiResponse GetDonNetMetrics(GetAllDotNetMetricsApiRequest request);
        AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request);

    }
}
