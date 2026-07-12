namespace DesignPatterns.AdapterFacadeCombination.Interfaces;

// ── YOUR COMMON INTERFACE ─────────────────────────────────────
// All adapters must implement this
// Facade talks to this — never to third parties directly
public interface IBookingService
{
    void Book(string name);    // common contract for all bookings
}