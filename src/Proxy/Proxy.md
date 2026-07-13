# The Proxy Pattern

> **One-sentence idea:** A proxy is a stand-in that implements the **same interface** as a real
> object, so it can sit in front of it and **control access** to it — the client thinks it's talking
> to the real thing.

The key move: the proxy and the real object are **interchangeable** (same interface). The client
holds a reference typed as the interface and can't tell which one it has. That lets the proxy
transparently insert behaviour *before, after, or instead of* forwarding the call.

---

## The problem it solves

Sometimes you can't (or don't want to) let a client talk to an object directly:

- The real object is **expensive to create** and you'd rather defer it until it's used.
- The object needs **access control** — not every caller may call every method.
- The object **lives somewhere else** (another process/machine) and the plumbing must be hidden.
- You want to **cache**, **log**, or **count** calls without touching the real object's code.

A proxy isolates that concern into a separate object that *looks identical* to the real one.

---

## The roles

| Role | What it is |
|---|---|
| **Subject** | The shared interface. The client depends only on this. |
| **RealSubject** | The actual object doing the real work — expensive, remote, or protected. |
| **Proxy** | Implements the same interface, holds (or obtains) the RealSubject, and controls access. |

```
Client ──▶ ISubject ◀── implements ── RealSubject
              ▲                              ▲
              └────── implements ── Proxy ───┘ (delegates to RealSubject)
```

The client holds an `ISubject` and unknowingly gets the **Proxy**, which decides when/whether to
touch the real object.

---

## Shared setup for every flavour

One interface, one real object, five proxies. The **structure is identical** every time — only the
bit *before/around the delegate call* changes. (Matches the code layout in this folder.)

```csharp
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
```

---

## 1. Virtual proxy — *delay expensive creation*

Don't build the real object until it's actually needed.

```csharp
public class VirtualReportProxy : IReportService
{
    private ReportService? _real;

    public string GetReport(int id)
    {
        _real ??= new ReportService();   // created on first use, then reused
        return _real.GetReport(id);
    }
}
```

**Takeaway:** cheap to hold, pays the cost only on first real use.

---

## 2. Protection proxy — *control who's allowed in*

Check permission, then forward (or refuse).

```csharp
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
```

**Takeaway:** same method, but access rules run before the real call.

---

## 3. Caching proxy — *remember results, skip repeat work*

Return a stored answer instead of hitting the real object again.

```csharp
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
```

```csharp
var svc = new CachingReportProxy(new ReportService());
svc.GetReport(1);   //   [real] building report 1...
svc.GetReport(1);   //   (nothing — served from cache)
```

**Takeaway:** the second call never reaches the real object.

---

## 4. Logging / smart-reference proxy — *add bookkeeping around the call*

Log, count, time, or lock — without touching the real class.

```csharp
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
```

**Takeaway:** cross-cutting concerns (logging, metrics, locking, ref-counting) live in the proxy,
not the real object.

---

## 5. Remote proxy — *stand in for an object that lives elsewhere*

Hide the network. The proxy looks local but calls across a process/machine boundary.

```csharp
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
```

**Takeaway:** the client calls `GetReport(id)` as if it were local; the proxy does the
serialization/transport. (In real life this stub is usually generated — e.g. a gRPC or WCF client.)

---

## All five at a glance

| Flavour | The bit inserted before/around `GetReport` | One-line purpose |
|---|---|---|
| **Virtual** | `_real ??= new ReportService()` | Delay expensive creation |
| **Protection** | permission check | Control access |
| **Caching** | look up / store result | Avoid repeat work |
| **Logging / smart** | log / count / lock | Add bookkeeping |
| **Remote** | network call | Hide "it's somewhere else" |

Notice: the structure is identical every time — implement the interface, hold the real object, do
something, then (usually) delegate. Only the "do something" differs. **That's the whole pattern.**

---

## When to use it

- Deferring an **expensive resource** until first use (virtual).
- Enforcing **access rules** uniformly in front of an object (protection).
- Hiding **remoteness** behind a local-looking object (remote).
- Adding **caching / logging / metrics** to an object you can't or don't want to modify.

## When *not* to

- If you don't need to *control access* — just add behaviour — that's often **Decorator**.
- If the extra indirection buys nothing (no laziness, protection, or remoting), it's just ceremony.
- In .NET, some proxy needs are already handled: `Lazy<T>` covers many virtual-proxy cases, and DI
  interceptors (Castle DynamicProxy, `DispatchProxy`) generate proxies at runtime.

## Common pitfalls

- **Interface drift** — the proxy must track the Subject interface. Share the interface so the
  compiler enforces it.
- **Hidden cost / surprise** — a virtual or remote proxy can turn an innocent-looking call into disk
  or network I/O (the classic ORM lazy-load "N+1 queries" trap). Make the expensive moment
  discoverable.
- **Thread safety** — lazy init (`_real ??= …`) isn't atomic. Under concurrency use `Lazy<T>` or a
  lock, or you may build the RealSubject twice.
- **Lifetime** — decide what the proxy does before the real object exists, and who disposes it.

---

## Proxy vs Decorator vs Adapter vs Facade

All four wrap another object. They're told apart by **intent**:

| Pattern | Interface vs wrapped | Intent |
|---|---|---|
| **Proxy** | **Same** interface | **Control access** (lazy, protect, remote, cache). Usually *owns/creates* the real object. |
| **Decorator** | **Same** interface | **Add behaviour**. Is *given* the object and layers on top; you stack many. |
| **Adapter** | **Different** interface | **Convert** one interface into another the client expects. |
| **Facade** | **New, simpler** interface | **Simplify** access to a whole subsystem. |

**Rule of thumb:** Proxy = same interface, *guards/controls* the object (and usually owns it).
Decorator = same interface, *enhances* the object (and is handed it). Adapter = *changes* the
interface. Facade = *simplifies* a subsystem. Proxy and Decorator share the same UML; the difference
is *why* you wrapped and *who owns* the wrapped object.
