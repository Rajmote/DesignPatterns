using DesignPatterns.Proxy;

namespace DesignPatterns.Proxy.VirtualProxy;
public class VirtualReportProxy : IReportService
{
    private ReportService? _real;

    public string GetReport(int id)
    {
        _real ??= new ReportService();   // created on first use, then reused
        return _real.GetReport(id);
    }
}

// Takeaway: cheap to hold, pays the cost only on first real use.