## Measure E2e Latency for a distributed system

# Setup
- Create new Application Insights and get the Instrumental Key
- update `Program.cs` with your instrument key
- run the console app by running `dotnet run`
- enter number of events to send
- this application will first send the `start` event, each with unique CorrelationId
- then it will send the `end` event for those CorrelationId
- run the `get-e2e-latency.kql` query in the App Insights Log screen
- you should be able to see 50, 90, 95 and 99 percentiles e2e latency
- the start event and the end event can run on 2 separate processes (2 separate web apps or Azure Functions)
