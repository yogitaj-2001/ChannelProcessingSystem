namespace ChannelProcessingFunctionsLibrary.Inputs;

public interface IInputs
{
    public double[]? ChannelDataInput { get; set; }
    public void acceptChannelInputFromFile(string? fileName);
    public void acceptChannelInputFromText(string? content);
}