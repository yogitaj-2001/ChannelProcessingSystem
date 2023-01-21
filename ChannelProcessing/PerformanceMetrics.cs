using ChannelProcessingFunctionsLibrary.Functions;
using ChannelProcessingFunctionsLibrary.Inputs;
using ChannelProcessingFunctionsLibrary.Parameters;

namespace ChannelProcessing;

public interface IPerformanceMetrics
{
    public Task<double> calculatePerformanceMetricsb(double[] input, IDictionary<string, double>? param);
    public Task<double[]> calculatePerformanceValueC(double[] input, IDictionary<string, double>? param);
    public Task<double> calculatePerformanceMetricsbFromFile(string inputFileName, string paramFileName);
    public Task<double[]> calculatePerformanceValueCFromFile(string inputFileName, string paramFileName);
    public Task<double> calculatePerformanceMetricsbFromStringContent(string inputContent, string paramContent);
    public Task<double[]> calculatePerformanceValueCFromStringContent(string inputContent, string paramContent);
}

public class PerformanceMetrics : IPerformanceMetrics
{
    private readonly IInputs _input;
    private readonly IParameters _param;
    private IFunctions _functions;

    public PerformanceMetrics()
    {
        _input = new Inputs();
        _param = new Parameters();
        _functions = new Functions();
    }

    public async Task<double> calculatePerformanceMetricsb(double[] input, IDictionary<string, double>? param)
    {
        try
        {
            _param.ParamDictionary = param;
            _input.ChannelDataInput = input;
            _param.ParamDictionary.TryGetValue("m", out double valueOfm);
            _param.ParamDictionary.TryGetValue("c", out double valueOfc);
            IIntermediateB intermediateB = new IntermediateB();
            IMetricb metricb = new Metricb();

            intermediateB.ValueOfc = valueOfc;
            intermediateB.ValueOfm = valueOfm;

            double[] valueOfB = new double[_input.ChannelDataInput.Length];

            for (int i = 0; i < _input.ChannelDataInput.Length; i++)
            {
                intermediateB.ValueOfX = _input.ChannelDataInput[i];
                valueOfB[i] = intermediateB.calculateB();
            }

            var valueOfb = await Task.Run(() => metricb.calculateMetricb(valueOfB));
            _functions.ValueOfb = valueOfb;
            return valueOfb;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<double[]> calculatePerformanceValueC(double[] input, IDictionary<string, double>? param)
    {
        try
        {
            var valueOfb = await Task.Run(() => calculatePerformanceMetricsb(input, param));

            double[] valueOfC = new double[_input.ChannelDataInput.Length];
            for (int i = 0; i < _input.ChannelDataInput.Length; i++)
            {
                _functions.ValueOfX = _input.ChannelDataInput[i];
                valueOfC[i] = _functions.calculateFunctionFour();
            }

            return valueOfC;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<double> calculatePerformanceMetricsbFromFile(string? inputFileName, string? paramFileName)
    {
        _input.acceptChannelInputFromFile(inputFileName);
        _param.acceptParametersFromFile(paramFileName);

        return await Task.Run(() => calculatePerformanceMetricsb(_input.ChannelDataInput, _param.ParamDictionary));
    }

    public async Task<double[]> calculatePerformanceValueCFromFile(string? inputFileName, string? paramFileName)
    {
        _input.acceptChannelInputFromFile(inputFileName);
        _param.acceptParametersFromFile(paramFileName);

        return await Task.Run(() => calculatePerformanceValueC(_input.ChannelDataInput, _param.ParamDictionary));
    }

    public async Task<double> calculatePerformanceMetricsbFromStringContent(string? inputContent, string? paramContent)
    {
        _input.acceptChannelInputFromText(inputContent);
        _param.acceptParametersFromText(paramContent);

        return await Task.Run(() => calculatePerformanceMetricsb(_input.ChannelDataInput, _param.ParamDictionary));
    }

    public async Task<double[]> calculatePerformanceValueCFromStringContent(string? inputContent, string? paramContent)
    {
        _input.acceptChannelInputFromText(inputContent);
        _param.acceptParametersFromText(paramContent);

        return await Task.Run(() => calculatePerformanceValueC(_input.ChannelDataInput, _param.ParamDictionary));
    }

}