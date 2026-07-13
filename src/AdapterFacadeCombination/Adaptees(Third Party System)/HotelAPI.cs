namespace DesignPatterns.AdapterFacadeCombination.Adaptees;

// ── THIRD PARTY SYSTEMS (Adaptees) ───────────────────────────
// Cannot change these — third party code
public class HotelAPI
{
    // HotelAPI calls it CheckIn — not Book
    public void CheckIn(string guest)
        => Console.WriteLine($"[HotelAPI] Room checked in for {guest}.");
}
