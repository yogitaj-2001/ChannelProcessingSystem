using System;
namespace ChannelProcessingFunctionsLibrary.Functions;

public interface IIntermediateB
{
    public double ValueOfX { get; set; }
    public double ValueOfm { get; set; }
    public double ValueOfc { get; set; }
    public double ValueOfB { get; set; }

    public double calculateB(double valueOfX, double valueOfm, double valueOfc);
    public double calculateB();
}

public class IntermediateB : IIntermediateB
{
    public double ValueOfX { get; set; }
    public double ValueOfm { get; set; }
    public double ValueOfc { get; set; }
    public double ValueOfB { get; set; }

    IFunctions _functions = new Functions();

    public double calculateB(double valueOfX, double valueOfm, double valueOfc)
    {
        var valueOfY = _functions.calculateFunctionOne(valueOfm, valueOfc, valueOfX);
        var valueOfA = _functions.calculateFunctionThree(valueOfX);
        ValueOfB = _functions.calculateFunctionTwo(valueOfA, valueOfY);
        return ValueOfB;
    }

    public double calculateB()
    {
        return calculateB(ValueOfX, ValueOfm, ValueOfc);
    }
}
