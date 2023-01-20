using ChannelProcessingFunctionsLibrary.Functions;
namespace ChannelProcessingTests.ChannelProcessingFunctionLibraryTests;

public class IntermediateBTests
{
    IIntermediateB function = new IntermediateB();

    [Theory]
    [InlineData(0.0, 0.0, 0, 0.0)]
    [InlineData(0.0, 0.0, 0.343543434, 2.910840089000217)]
    [InlineData(2.0, 0.0, 0.343543434, 3.597926957000217)]
    [InlineData(0.0, 0.5, 0.343543434, 3.410840089000217)]
    [InlineData(2.0, 0.5, 0.343543434, 4.097926957000217)]
    public void calculateB_Success(double valueOfm, double valueOfc, double valueOfX, double expectedResult)
    {
        var actualResult = function.calculateB(valueOfX, valueOfm, valueOfc);
        Assert.Equal(expectedResult, function.ValueOfB);
        Assert.Equal(expectedResult, actualResult);
    }
}
