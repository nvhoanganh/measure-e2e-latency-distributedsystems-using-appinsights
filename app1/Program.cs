using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
// input
namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var rand = new Random();

      var configuration = TelemetryConfiguration.CreateDefault();
      configuration.InstrumentationKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
      var telemetryClient = new TelemetryClient(configuration);

      var correlationIds = new List<string>();
      Console.WriteLine("How many records to send?");

      var samplesToSend = int.Parse(Console.ReadLine());
      for (int i = 0; i < samplesToSend; i++)
      {
        var guidId = System.Guid.NewGuid().ToString();
        correlationIds.Add(guidId);
        // send start event
        telemetryClient.TrackTrace(guidId, SeverityLevel.Information, new Dictionary<string, string> {
                { "correlationId", guidId },
                { "type", "start" },
            });
        Console.WriteLine($"Sent Start - {guidId}");
      }

      foreach (var item in correlationIds)
      {
        // send start event
        telemetryClient.TrackTrace(item, SeverityLevel.Information, new Dictionary<string, string> {
                { "correlationId", item },
                { "type", "end" },
            });

        Task.Delay(rand.Next(200, 500)).Wait();
        Console.WriteLine($"Sent End - {item}");
      }

      telemetryClient.Flush();
      Task.Delay(5000).Wait();
      Console.WriteLine($"Done");
    }
  }
}