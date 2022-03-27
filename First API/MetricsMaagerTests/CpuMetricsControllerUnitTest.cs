using First_API.Controllers;
using First_API.Interfaces;
using First_API.Requests;
using First_API.SQLmetricitem;
using Moq;
using System;
using Xunit;


namespace MetricsMaagerTests
{

    public class CpuMetricsControllerUnitTests
    {
        //private readonly CpuMetricsController controller;

        //private Mock<CpuMetricsController> mock;
        //public CpuMetricsControllerUnitTests()
        //{
        //    mock = new Mock<CpuMetricsController>();
        //    controller = new CpuMetricsController();
        //}

        //[Fact]
        //public void Create_ShouldCall_Create_From_Repository()
        //{
        //    // Устанавливаем параметр заглушки
        //    // В заглушке прописываем, что в репозиторий прилетит CpuMetric - объект
        //    mock.Setup(repository => repository.Create(It.IsAny<CpuMetricCreateRequest>())).Verifiable();

        //    // Выполняем действие на контроллере
        //    var result = controller.Create(new
        //        CpuMetricCreateRequest
        //    {
        //        Time = 1,
        //        Value = 50,
              
        //    });
        //    // Проверяем заглушку на то, что пока работал контроллер
        //    // Вызвался метод Create репозитория с нужным типом объекта в параметре
        //    mock.Verify(repository => repository.Create(It.IsAny<CpuMetricCreateRequest>()),
        //    Times.AtMostOnce());
        //}
    }
    
}