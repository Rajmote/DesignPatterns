using DesignPatterns.AdapterFacadeCombination.Adaptees;
using DesignPatterns.AdapterFacadeCombination.Adapters;
using DesignPatterns.AdapterFacadeCombination.Interfaces;

namespace DesignPatterns.AdapterFacadeCombination.Facade;

// ── FACADE ────────────────────────────────────────────────────
// Single entry point — hides all adapters and third parties
// Customer only talks to this
public class TravelFacade
{
    // Facade uses adapters — not third parties directly
    private IBookingService _flightBooking;
    private IBookingService _hotelBooking;
    private IBookingService _cabBooking;

    public TravelFacade()
    {
        // Wire adapters to their third party systems
        _flightBooking = new FlightAdapter(new FlightAPI());
        _hotelBooking = new HotelAdapter(new HotelAPI());
        _cabBooking = new CabAdapter(new CabAPI());
    }

    // One simple method — books entire trip
    public void BookTrip(string name)
    {
        Console.WriteLine($"\n[TravelFacade] Booking full trip for {name}...\n");

        _flightBooking.Book(name);    // adapter handles translation
        _hotelBooking.Book(name);     // adapter handles translation
        _cabBooking.Book(name);       // adapter handles translation

        Console.WriteLine($"\n[TravelFacade] Trip fully booked for {name}!\n");
    }
}
