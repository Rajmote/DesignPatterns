namespace DesignPatterns.Adapter;
// ── GPAY ──────────────────────────────────────────────────────
// Another third party — also different method name
public class GPay
{
    // GPay calls it Pay — not ProcessPayment
    public void Pay(decimal amount)
        => Console.WriteLine($"[GPay] Paying ${amount} via Google Pay.");
}