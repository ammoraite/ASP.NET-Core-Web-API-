//using MetricsMeneger.Controllers;
//using MetricsMeneger.Controllers.MetricControllers.Base;
//using MetricsMeneger.DAL.Modules;
//using Moq;
//using MetricsMeneger.DTO.Requests;
//using Xunit;
//namespace MetricsAgentTests
//{
//    public class CpuMetricsControllerUnitTests
//    {
//        private CpuMetricsController controller;
            
//        private Mock<ICpuMetricRepository> mock;
//        public CpuMetricsControllerUnitTests()
//        {
//            mock = new Mock<ICpuMetricRepository>();
//            controller = new CpuMetricsController(mock.Object);
//        }
//        [Fact]
//        public void Create_ShouldCall_Create_From_Repository()
//        {
//            // ������������� �������� ��������
//            // � �������� �����������, ��� � ����������� �������� CpuMetric - ������
//            mock.Setup(repository =>
//                repository.Create(It.IsAny<CpuMetric>())).Verifiable();
//            // ��������� �������� �� �����������
//            var result = controller.Create(new
//                CpuRequestMetricCreate()
//            {
//                    Time = 1,
//                    Value = 50
//                });
//            // ��������� �������� �� ��, ��� ���� ������� ����������
//            // �������� ����� Create ����������� � ������ ����� ������� � ���������
//            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),
//                Times.AtMostOnce());
//        }
//    }
//}

