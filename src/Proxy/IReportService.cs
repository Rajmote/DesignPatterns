namespace DesignPatterns.Proxy;

// SUBJECT — the shared contract every proxy and the real object implement.
public interface IReportService
{
    string GetReport(int id);
}

// REAL SUBJECT — the actual work (imagine it's slow/expensive).
public class ReportService : IReportService
{
    public string GetReport(int id)
    {
        Console.WriteLine($"  [real] building report {id}...");
        return $"Report#{id}";
    }
}

// Every proxy implements IReportService, so the client can't tell it's holding a proxy.
