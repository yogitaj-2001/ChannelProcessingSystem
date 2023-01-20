using System;
namespace ChannelProcessingFunctionsLibrary.Functions;

public interface IMetricb
{
    public double[]? ValuesOfB { get; set; }
    public double calculateMetricb(double[] valuesOfB);
    public double calculateMetricb();
}

public class Metricb : IMetricb
{
    public double[]? ValuesOfB { get; set; }

    public double calculateMetricb(double[] valuesOfB)
    {
        if (valuesOfB.Length > 0)
        {
            return Queryable.Average(valuesOfB.AsQueryable());
        }
        else
        {
            return 0;
        }
    }

    public double calculateMetricb()
    {
        return calculateMetricb(ValuesOfB);
    }
}