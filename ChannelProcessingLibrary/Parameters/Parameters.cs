namespace ChannelProcessingFunctionsLibrary.Parameters
{
    public class Parameters : IParameters
    {
        public IDictionary<string, double>? ParamDictionary { get; set; }

        public Parameters()
        {
        }

        public Parameters(Dictionary<string, double> paramDictionary)
        {
            ParamDictionary = paramDictionary;
        }

        public void acceptParametersFromText(string? content)
        {
            string[] lines = content.Split(new string[] { "\n" }
                              , StringSplitOptions.None
                              );

            ParamDictionary =
lines.Where(line => !string.IsNullOrWhiteSpace(line)) // to be on the safe side
.Select(line => line.Split(','))
  .Select(items => new
  {
      key = items[0],
      value = double.Parse(items[1])
  }).ToDictionary(item => item.key, item => item.value);
        }

        public void acceptParametersFromFile(string? fileName)
        {

            acceptParametersFromText(File.ReadAllText(fileName));
        }

    }
}