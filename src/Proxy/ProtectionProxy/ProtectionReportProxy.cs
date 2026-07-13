namespace DesignPatterns.Proxy.ProtectionProxy;

public class ProtectionReportProxy : IReportService
{
    private readonly IReportService _real;
    private readonly bool _isAdmin;
    public ProtectionReportProxy(IReportService real, bool isAdmin)
    { _real = real; _isAdmin = isAdmin; }

    public string GetReport(int id)
    {
        if (!_isAdmin)
            throw new UnauthorizedAccessException("Not allowed.");
        return _real.GetReport(id);      // gate, then delegate
    }
}

// Takeaway: same method, but access rules run before the real call.