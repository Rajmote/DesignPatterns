namespace DesignPatterns.Adapter;
// ── PAYPAL ADAPTER ────────────────────────────────────────────
// Wraps PayPal and makes it look like IPaymentProcessor
// Store thinks it is talking to IPaymentProcessor
// Actually talking to PayPal underneath
public class PayPalAdapter : IPaymentProcessor
{
    private PayPal _payPal;    // the real PayPal object inside

    public PayPalAdapter(PayPal payPal) => _payPal = payPal;

    // Store calls ProcessPayment()
    // Adapter translates it to PayPal.SendMoney()
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("[PayPalAdapter] Translating to PayPal...");
        _payPal.SendMoney(amount);    // translated call
    }
}