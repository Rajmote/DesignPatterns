namespace DesignPatterns.Adapter;
// ── ONLINE STORE ──────────────────────────────────────────────
// Only knows IPaymentProcessor — never PayPal or GPay directly
// Swap payment provider anytime — store code never changes
public class OnlineStore
{
    private IPaymentProcessor _processor;

    public OnlineStore(IPaymentProcessor processor)
        => _processor = processor;

    public void Checkout(decimal amount)
    {
        Console.WriteLine($"[Store] Processing checkout for ${amount}...");
        _processor.ProcessPayment(amount);    // store does not care who handles it
        Console.WriteLine("[Store] Payment done!\n");
    }
}
