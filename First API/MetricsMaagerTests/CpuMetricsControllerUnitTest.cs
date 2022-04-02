using Moq;
using System;
using First_API.Controllers;
using First_API.DAL.Modules;
using Xunit;
using First_API.Controllers.MetricControllers.Base;
using First_API.DTO.Requests;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricRepository> mock;
        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricRepository>();

            controller = new CpuMetricsController(mock.Object);
        }
        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // Устанавливаем параметр заглушки
            // В заглушке прописываем, что в репозиторий прилетит CpuMetric - объект
            mock.Setup(repository =>
                repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            // Выполняем действие на контроллере
            var result = controller.Create(new
                CpuRequestMetricCreate
            {
                    Time = 1,
                    Value = 50
                });
            // Проверяем заглушку на то, что пока работал контроллер
            // Вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),
                Times.AtMostOnce());
        }
    }
}