using First_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;


namespace MetricsMaagerTests
{
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController controller;
        public DotNetMetricsControllerUnitTest()
        {
            controller = new DotNetMetricsController();
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
