namespace DesignPatterns.Adapter;
// ── YOUR INTERFACE ────────────────────────────────────────────
// What your online store expects — your own contract
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
