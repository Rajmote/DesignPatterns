namespace DesignPatterns.Proxy.RemoteProxy;

public class RemoteReportProxy : IReportService
{
    private readonly HttpClient _http = new();

    public string GetReport(int id)
    {
        // Network plumbing hidden behind the same simple method.
        Console.WriteLine($"  [remote] GET /reports/{id}");
        return _http.GetStringAsync($"https://api.example.com/reports/{id}")
                    .GetAwaiter().GetResult();
    }
}

// Takeaway: the client calls GetReport(id) as if it were local; 
// the proxy does the serialization/transport. (In real life this stub is usually generated — e.g. a gRPC or WCF client.)
