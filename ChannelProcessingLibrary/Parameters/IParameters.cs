namespace ChannelProcessingFunctionsLibrary.Parameters;

public interface IParameters
{
    public IDictionary<string, double> ParamDictionary { get; set; }
    public void acceptParametersFromFile(string? fileName);
    public void acceptParametersFromText(string? content);
}