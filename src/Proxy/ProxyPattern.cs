using DesignPatterns.Proxy.CachingProxy;
using DesignPatterns.Proxy.LoggingOrSmartRefProxy;
using DesignPatterns.Proxy.ProtectionProxy;
using DesignPatterns.Proxy.VirtualProxy;

namespace DesignPatterns.Proxy;

// Client — demonstrates the proxy flavours.
// (RemoteReportProxy is omitted: it makes a real HTTP call.)
public class ProxyPattern
{
    public void Run()
    {
        // Virtual — the real object is built only on first use.
        IReportService virtualProxy = new VirtualReportProxy();
        virtualProxy.GetReport(1);

        // Protection — an admin is allowed, a guest is blocked.
        IReportService admin = new ProtectionReportProxy(new ReportService(), isAdmin: true);
        admin.GetReport(2);

        IReportService guest = new ProtectionReportProxy(new ReportService(), isAdmin: false);
        try
        {
            guest.GetReport(3);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"  [blocked] {ex.Message}");
        }

        // Caching — the second call is served from the cache (no real work).
        IReportService caching = new CachingReportProxy(new ReportService());
        caching.GetReport(4);
        caching.GetReport(4);

        // Logging — before/after bookkeeping wraps the real call.
        IReportService logging = new LoggingReportProxy(new ReportService());
        logging.GetReport(5);
    }
}
