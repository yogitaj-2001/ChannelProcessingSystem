using ChannelProcessing;
using Microsoft.AspNetCore.Mvc;

namespace ChannelProcessingAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChannelProcessingController : ControllerBase
{
    private readonly ILogger<ChannelProcessingController> _logger;

    private readonly IPerformanceMetrics _performanceMetrics;

    public ChannelProcessingController(ILogger<ChannelProcessingController> logger, IPerformanceMetrics performanceMetrics)
    {
        _logger = logger;
        _performanceMetrics = performanceMetrics;
    }

    [HttpPost("Metricb")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public ActionResult<double> postMetricb([FromBody][Bind("ChannelProcessingRequest")] ChannelProcessingRequest channelProcessingRequest)
    {
        try
        {

            if (channelProcessingRequest?.ParamDictionary?.Count == 0 || channelProcessingRequest?.ChannelData?.Length == 0)
            {
                return BadRequest();
            }
            return Ok(_performanceMetrics.calculatePerformanceMetricsb(channelProcessingRequest?.ChannelData, channelProcessingRequest?.ParamDictionary));
        }
        catch (Exception ex)
        {
            _logger.LogError("Error calling postMetricb", ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("PerformanceValueC")]
    public ActionResult<double[]> postPerformanceValueC([FromBody][Bind("ChannelProcessingRequest")] ChannelProcessingRequest channelProcessingRequest)
    {
        try
        {

            if (channelProcessingRequest?.ParamDictionary?.Count == 0 || channelProcessingRequest?.ChannelData?.Length == 0)
            {
                return BadRequest();
            }
            return Ok(_performanceMetrics.calculatePerformanceValueC(channelProcessingRequest?.ChannelData, channelProcessingRequest?.ParamDictionary));
        }
        catch (Exception ex)
        {
            _logger.LogError("Error calling postPerformanceValueC", ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

