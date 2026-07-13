namespace DesignPatterns.Proxy.CachingProxy;

public class CachingReportProxy : IReportService
{
    private readonly IReportService _real;
    private readonly Dictionary<int, string> _cache = new();
    public CachingReportProxy(IReportService real) => _real = real;

    public string GetReport(int id)
    {
        if (_cache.TryGetValue(id, out var cached))
            return cached;               // cache hit — no real call
        return _cache[id] = _real.GetReport(id);
    }
}


// var svc = new CachingReportProxy(new ReportService());
// svc.GetReport(1);   //   [real] building report 1...
// svc.GetReport(1);   //   (nothing — served from cache)

//Takeaway: the second call never reaches the real object.