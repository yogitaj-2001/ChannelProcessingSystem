using ChannelProcessing;

namespace ChannelProcessingDemo;

internal class Program
{
    static void Main(string[] args)
    {
        string inputFileName, outputFileName, paramFileName;

        // Display title as the C# console calculator app.
        Console.WriteLine("Car/Boat Performance Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        // Ask the user to type the input file name.
        Console.WriteLine("Type a input file name (full path), and then press Enter");
        inputFileName = Console.ReadLine();

        // Ask the user to type the param file name.
        Console.WriteLine("Type a param file name (full path), and then press Enter");
        paramFileName = Console.ReadLine();

        // Ask the user to type the output file name.
        Console.WriteLine("Type a output file name (full path), and then press Enter");
        outputFileName = Console.ReadLine();

        // Ask the user to choose an option.
        Console.WriteLine("Choose an option from the following list:");
        Console.WriteLine("\tb - Calculate Metric b");
        Console.WriteLine("\tc - Calculate C");
        Console.Write("Your option? ");

        PerformanceMetrics pm = new PerformanceMetrics();
        // Use a switch statement to do the math.
        switch (Console.ReadLine())
        {
            case "b":
                var valueOfb = pm.calculatePerformanceMetricsbFromFile(inputFileName, paramFileName);
                File.WriteAllText(outputFileName, "b, " + valueOfb);
                Console.Write($"Your Output {valueOfb}");
                break;
            case "c":
                var valueOfC = pm.calculatePerformanceValueCFromFile(inputFileName, paramFileName);
                File.WriteAllText(outputFileName, "C, " + string.Join(", ", valueOfC));
                break;
        }
        // Wait for the user to respond before closing.
        Console.WriteLine($"Your Output is also written to {outputFileName}");
        Console.WriteLine("Press any key to close the Performance Calculator console app...");
        Console.ReadKey();
    }
}