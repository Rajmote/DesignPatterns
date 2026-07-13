namespace DesignPatterns.AdapterFacadeCombination.Adaptees;

// ── THIRD PARTY SYSTEMS (Adaptees) ───────────────────────────
// Cannot change these — third party code
public class CabAPI
{
    // CabAPI calls it RequestRide — not Book
    public void RequestRide(string passenger)
        => Console.WriteLine($"[CabAPI] Cab requested for {passenger}.");
}
