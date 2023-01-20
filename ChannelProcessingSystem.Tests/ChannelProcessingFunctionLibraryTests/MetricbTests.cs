using ChannelProcessingFunctionsLibrary.Functions;
namespace ChannelProcessingTests.ChannelProcessingFunctionLibraryTests;

public class MetricbTests
{
    IMetricb metric = new Metricb();

    [Fact]
    public void calculateMetricb_Success()
    {
        double[] valuesOfB = { 0.3434343, 0.3434343, 0.7676767, 0.978787878 };
        var actualResult = metric.calculateMetricb(valuesOfB);
        Assert.Equal(Queryable.Average(valuesOfB.AsQueryable()), actualResult);
    }
}
