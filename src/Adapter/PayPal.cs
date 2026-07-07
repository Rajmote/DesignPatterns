// ── PAYPAL ────────────────────────────────────────────────────
// Third party class — you cannot change this
// Has different method name than your interface expects
public class PayPal
{
    // PayPal calls it SendMoney — not ProcessPayment
    public void SendMoney(decimal amount)
        => Console.WriteLine($"[PayPal] Sending ${amount} via PayPal.");
}