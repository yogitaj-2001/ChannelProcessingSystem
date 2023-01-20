namespace ChannelProcessingFunctionsLibrary.Inputs;

public class Inputs : IInputs
{
    public double[]? ChannelDataInput { get; set; }

    public Inputs()
    {
    }

    public Inputs(double[] channelDataInput)
    {
        ChannelDataInput = channelDataInput;
    }

    public void acceptChannelInputFromFile(string? fileName)
    {
        try
        {
            var array = File.ReadAllText(fileName).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Skip<string>(1);
            ChannelDataInput = Array.ConvertAll(array.ToArray(), Double.Parse);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void acceptChannelInputFromText(string? content)
    {
        try
        {
            var array = content?.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Skip<string>(1);
            ChannelDataInput = Array.ConvertAll(array.ToArray(), Double.Parse); ChannelDataInput = Array.ConvertAll(array.ToArray(), Double.Parse);
        }
        catch (Exception)
        {
            throw;
        }
    }

}

