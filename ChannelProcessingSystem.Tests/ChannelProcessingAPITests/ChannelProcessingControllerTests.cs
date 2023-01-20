using ChannelProcessing;
using ChannelProcessingAPI;
using ChannelProcessingAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
namespace ChannleProcessing.Tests.ChannelProcessingAPITests;

public class ChannelProcessingControllerTests
{
    Mock<ILogger<ChannelProcessingController>> _logger = new Mock<ILogger<ChannelProcessingController>>();
    IPerformanceMetrics metric = new PerformanceMetrics();
    ChannelProcessingController controller;

    public ChannelProcessingControllerTests()
    {
        controller = new ChannelProcessingController(_logger.Object, metric);
    }

    [Fact]
    public void Metricb_Success_200OK()
    {
        // Arrange
        ChannelProcessingRequest request = new ChannelProcessingRequest
        {
            ChannelData = new double[] {
            0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434},
            ParamDictionary = new Dictionary<string, double> { { "m", 2.0 }, { "c", 0.5 } }
        };

        // Act

        var result = controller.postMetricb(request);

        // Assert
        OkObjectResult okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.IsType<double>(okResult.Value);
    }

    [Fact]
    public void PerformanceValueC_Success_200OK()
    {
        // Arrange
        ChannelProcessingRequest request = new ChannelProcessingRequest
        {
            ChannelData = new double[] {
            0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434},
            ParamDictionary = new Dictionary<string, double> { { "m", 2.0 }, { "c", 0.5 } }
        };

        // Act

        var result = controller.postPerformanceValueC(request);

        // Assert
        OkObjectResult okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.IsType<double[]>(okResult.Value);
    }

    [Fact]
    public void Metricb_400BadRequest()
    {
        // Arrange
        ChannelProcessingRequest request = new ChannelProcessingRequest
        {
            ChannelData = new double[] { },
            ParamDictionary = new Dictionary<string, double> { }
        };

        // Act

        var result = controller.postMetricb(request);

        // Assert
        BadRequestResult badResult = result.Result as BadRequestResult;
        Assert.NotNull(badResult);
        Assert.Equal(400, badResult.StatusCode);
    }

    [Fact]
    public void PerformanceValueC_400BadRequest()
    {
        // Arrange
        ChannelProcessingRequest request = new ChannelProcessingRequest
        {
            ChannelData = new double[] { },
            ParamDictionary = new Dictionary<string, double> { }
        };

        // Act

        var result = controller.postPerformanceValueC(request);

        // Assert
        BadRequestResult badResult = result.Result as BadRequestResult;
        Assert.NotNull(badResult);
        Assert.Equal(400, badResult.StatusCode);
    }

    [Fact]
    public void Metricb_500InternalServerError()
    {
        // Arrange
        Mock<IPerformanceMetrics> mockMetric = new Mock<IPerformanceMetrics>();

        mockMetric.Setup(m => m.calculatePerformanceMetricsb(It.IsAny<double[]>(), It.IsAny<Dictionary<string, double>>())).Throws<Exception>();
        ChannelProcessingController controller1 = new ChannelProcessingController(_logger.Object, mockMetric.Object);

        ChannelProcessingRequest request = new ChannelProcessingRequest
        {
            ChannelData = new double[] {
            0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434},
            ParamDictionary = new Dictionary<string, double> { { "a", 2.0 }, { "b", 0.5 } }
        };

        // Act

        var result = controller1.postMetricb(request);

        // Assert
        StatusCodeResult errorResult = result.Result as StatusCodeResult;
        Assert.NotNull(result);
        Assert.Equal(500, errorResult.StatusCode);
    }

    [Fact]
    public void PerformanceValueC_500InternalServerError()
    {
        // Arrange
        Mock<IPerformanceMetrics> mockMetric = new Mock<IPerformanceMetrics>();

        mockMetric.Setup(m => m.calculatePerformanceValueC(It.IsAny<double[]>(), It.IsAny<Dictionary<string, double>>())).Throws<Exception>();
        ChannelProcessingController controller1 = new ChannelProcessingController(_logger.Object, mockMetric.Object);

        ChannelProcessingRequest request = new ChannelProcessingRequest
        {
            ChannelData = new double[] {
            0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434},
            ParamDictionary = new Dictionary<string, double> { { "m", 2.0 }, { "c", 0.5 } }
        };

        // Act

        var result = controller1.postPerformanceValueC(request);

        // Assert
        StatusCodeResult errorResult = result.Result as StatusCodeResult;
        Assert.NotNull(result);
        Assert.Equal(500, errorResult.StatusCode);
    }
}
