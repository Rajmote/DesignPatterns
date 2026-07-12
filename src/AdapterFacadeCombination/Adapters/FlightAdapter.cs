using DesignPatterns.AdapterFacadeCombination.Adaptees;
using DesignPatterns.AdapterFacadeCombination.Interfaces;

namespace DesignPatterns.AdapterFacadeCombination.Adapters;

// ── ADAPTERS ──────────────────────────────────────────────────
// Each wraps one third party and makes it look like IBookingService
public class FlightAdapter : IBookingService
{
    private FlightAPI _flightAPI;    // third party inside

    public FlightAdapter(FlightAPI flightAPI) => _flightAPI = flightAPI;

    // Translates Book() → FlightAPI.ReserveSeat()
    public void Book(string name)
    {
        Console.WriteLine("[FlightAdapter] Translating to FlightAPI...");
        _flightAPI.ReserveSeat(name);
    }
}