using System;
namespace ChannelProcessingFunctionsLibrary.Functions;

public interface IFunctions
{
    public double ValueOfm { get; set; }
    public double ValueOfc { get; set; }
    public double ValueOfX { get; set; }
    public double ValueOfb { get; set; }
    public double ValueOfA { get; set; }
    public double ValueOfY { get; set; }

    public double calculateFunctionOne(double valueOfm, double valueOfc, double valueOfX);
    public double calculateFunctionTwo(double ValueOfA, double ValueOfY);
    public double calculateFunctionThree(double ValueOfX);
    public double calculateFunctionFour(double valueOfb, double valueOfX);

    public double calculateFunctionOne();
    public double calculateFunctionTwo();
    public double calculateFunctionThree();
    public double calculateFunctionFour();
}

public class Functions : IFunctions
{
    public double ValueOfm { get; set; }
    public double ValueOfc { get; set; }
    public double ValueOfX { get; set; }
    public double ValueOfb { get; set; }
    public double ValueOfA { get; set; }
    public double ValueOfY { get; set; }

    public double calculateFunctionOne(double valueOfm, double valueOfc, double valueOfX)
    {
        return valueOfm * valueOfX + valueOfc;
    }

    public double calculateFunctionOne()
    {
        return calculateFunctionOne(ValueOfm, ValueOfc, ValueOfX);
    }

    public double calculateFunctionTwo(double valueOfA, double valueOfY)
    {
        return valueOfA + valueOfY;
    }

    public double calculateFunctionTwo()
    {
        return calculateFunctionTwo(ValueOfA, ValueOfY);
    }

    public double calculateFunctionThree(double valueOfX)
    {
        if (valueOfX == 0)
        {
            return 0;
        }
        else
        {
            return 1 / valueOfX;
        }
    }

    public double calculateFunctionThree()
    {
        return calculateFunctionThree(ValueOfX);
    }

    public double calculateFunctionFour(double valueOfb, double valueOfX)
    {
        return valueOfX + valueOfb;
    }

    public double calculateFunctionFour()
    {
        return calculateFunctionFour(ValueOfb, ValueOfX);
    }
}