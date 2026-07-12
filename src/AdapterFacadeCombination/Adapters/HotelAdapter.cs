using DesignPatterns.AdapterFacadeCombination.Adaptees;
using DesignPatterns.AdapterFacadeCombination.Interfaces;

namespace DesignPatterns.AdapterFacadeCombination.Adapters;

// ── ADAPTERS ──────────────────────────────────────────────────
// Each wraps one third party and makes it look like IBookingService
public class HotelAdapter : IBookingService
{
    private HotelAPI _hotelAPI;    // third party inside

    public HotelAdapter(HotelAPI hotelAPI) => _hotelAPI = hotelAPI;

    // Translates Book() → HotelAPI.CheckIn()
    public void Book(string name)
    {
        Console.WriteLine("[HotelAdapter] Translating to HotelAPI...");
        _hotelAPI.CheckIn(name);
    }
}