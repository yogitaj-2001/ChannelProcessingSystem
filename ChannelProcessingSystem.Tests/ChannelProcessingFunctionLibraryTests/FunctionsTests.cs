using ChannelProcessingFunctionsLibrary.Functions;
namespace ChannelProcessingTests.ChannelProcessingFunctionLibraryTests;

public class FunctionsTests
{
    IFunctions function = new Functions();

    [Theory]
    [InlineData(0.0, 0.0, 0, 0.0)]
    [InlineData(0.0, 0.0, 0.343543434, 0.0)]
    [InlineData(2.0, 0.0, 0.343543434, 0.687086868)]
    [InlineData(0.0, 0.5, 0.343543434, 0.5)]
    [InlineData(2.0, 0.5, 0.343543434, 1.187086868)]
    public void calculateFunctionOne_Success(double valueOfm, double valueOfc, double valueOfX, double expectedResult)
    {
        var actualResult = function.calculateFunctionOne(valueOfm, valueOfc, valueOfX);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(0.1, 0.2, 0.30000000000000004)]
    [InlineData(0.0, 0.1, 0.1)]
    [InlineData(0.1, 0.0, 0.1)]
    [InlineData(0.0, 0.0, 0.0)]
    public void calculateFunctionTwo_Success(double valueOfA, double valueOfY, double expectedResult)
    {
        var actualResult = function.calculateFunctionTwo(valueOfA, valueOfY);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(0.3545225, 2.820695442461339)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void calculateFunctionThree_Success(double valueOfX, double expectedResult)
    {
        var actualResult = function.calculateFunctionThree(valueOfX);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(0.1, 0.2, 0.30000000000000004)]
    [InlineData(0.0, 0.1, 0.1)]
    [InlineData(0.1, 0.0, 0.1)]
    [InlineData(0.0, 0.0, 0.0)]
    public void calculateFunctionFour_Success(double valueOfb, double valueOfX, double expectedResult)
    {
        var actualResult = function.calculateFunctionFour(valueOfb, valueOfX);
        Assert.Equal(expectedResult, actualResult);
    }
}
