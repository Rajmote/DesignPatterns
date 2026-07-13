using DesignPatterns.AdapterFacadeCombination.Adaptees;
using DesignPatterns.AdapterFacadeCombination.Interfaces;

namespace DesignPatterns.AdapterFacadeCombination.Adapters;

// ── ADAPTERS ──────────────────────────────────────────────────
// Each wraps one third party and makes it look like IBookingService
public class CabAdapter : IBookingService
{
    private CabAPI _cabAPI;    // third party inside

    public CabAdapter(CabAPI cabAPI) => _cabAPI = cabAPI;

    // Translates Book() → CabAPI.RequestRide()
    public void Book(string name)
    {
        Console.WriteLine("[CabAdapter] Translating to CabAPI...");
        _cabAPI.RequestRide(name);
    }
}
