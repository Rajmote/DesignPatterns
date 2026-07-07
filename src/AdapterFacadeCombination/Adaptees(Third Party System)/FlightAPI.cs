// ── THIRD PARTY SYSTEMS (Adaptees) ───────────────────────────
// Cannot change these — third party code

public class FlightAPI
{
    // FlightAPI calls it ReserveSeat — not Book
    public void ReserveSeat(string passenger)
        => Console.WriteLine($"[FlightAPI] Seat reserved for {passenger}.");
}