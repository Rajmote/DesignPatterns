namespace DesignPatterns.Adapter;
// ── GPAY ADAPTER ──────────────────────────────────────────────
// Wraps GPay and makes it look like IPaymentProcessor
// Store thinks it is talking to IPaymentProcessor
// Actually talking to GPay underneath
public class GPayAdapter : IPaymentProcessor
{
    private GPay _gpay;    // the real GPay object inside

    public GPayAdapter(GPay gpay) => _gpay = gpay;

    // Store calls ProcessPayment()
    // Adapter translates it to GPay.Pay()
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("[GPayAdapter] Translating to GPay...");
        _gpay.Pay(amount);    // translated call
    }
}