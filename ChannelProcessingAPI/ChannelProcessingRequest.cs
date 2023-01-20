namespace ChannelProcessingAPI;
    public class ChannelProcessingRequest
    {
        public double[]? ChannelData { get; init; }
        public IDictionary<string, double>? ParamDictionary { get; init; }
    }