namespace DesignPatterns.Proxy.LoggingOrSmartRefProxy;

public class LoggingReportProxy : IReportService
{
    private readonly IReportService _real;
    public LoggingReportProxy(IReportService real) => _real = real;

    public string GetReport(int id)
    {
        Console.WriteLine($"  [log] GetReport({id}) called");
        var result = _real.GetReport(id);
        Console.WriteLine($"  [log] GetReport({id}) returned");
        return result;                   // wrap the delegate with before/after
    }
}

//Takeaway: cross-cutting concerns (logging, metrics, locking, ref-counting) live in the proxy, not the real object.