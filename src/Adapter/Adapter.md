# Adapter Pattern
## Payment Gateway Example

---

## What is it?
Converts one interface into another that the client expects.
Makes incompatible interfaces work together without changing existing code.

---

## The Situation
Your app speaks → IPaymentProcessor (your interface)
You want to use → PayPal and GPay (both have different method names)
Problem → Neither matches your interface
Solution → Write adapters that translate

---
## Who Does What?
### IPaymentProcessor (Your Interface)
- What your app understands
- Has ProcessPayment() method
- Your app only talks to this — never to PayPal or GPay directly
### PayPal (Adaptee)
- Third party class you cannot change
- Has SendMoney() instead of ProcessPayment()
- Does the real payment work
### GPay (Adaptee)
- Another third party you cannot change
- Has Pay() instead of ProcessPayment()
- Does the real payment work
### PayPalAdapter (Adapter)
- Implements IPaymentProcessor so store accepts it
- Holds PayPal inside
- Translates ProcessPayment() → PayPal.SendMoney()
### GPayAdapter (Adapter)
- Implements IPaymentProcessor so store accepts it
- Holds GPay inside
- Translates ProcessPayment() → GPay.Pay()
### OnlineStore (Client)
- Only knows IPaymentProcessor
- Has no idea PayPal or GPay exists
- Nothing changes in store when you swap payment provider
---
## The Flow
OnlineStore
└── calls ProcessPayment()
└── Adapter receives it
└── Adapter translates the call
└── PayPal.SendMoney() or GPay.Pay() runs
└── Payment done

---
## The Code
```csharp
// ── YOUR INTERFACE ────────────────────────────────────────────
// What your online store expects — your own contract
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
// ── PAYPAL ────────────────────────────────────────────────────
// Third party class — you cannot change this
// Has different method name than your interface expects
public class PayPal
{
    // PayPal calls it SendMoney — not ProcessPayment
    public void SendMoney(decimal amount)
        => Console.WriteLine($"[PayPal] Sending ${amount} via PayPal.");
}
// ── GPAY ──────────────────────────────────────────────────────
// Another third party — also different method name
public class GPay
{
    // GPay calls it Pay — not ProcessPayment
    public void Pay(decimal amount)
        => Console.WriteLine($"[GPay] Paying ${amount} via Google Pay.");
}
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
// ── PROGRAM ───────────────────────────────────────────────────
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Pay with PayPal ===\n");
        var payPalStore = new OnlineStore(new PayPalAdapter(new PayPal()));
        payPalStore.Checkout(99.99m);
        Console.WriteLine("=== Pay with GPay ===\n");
        var gPayStore = new OnlineStore(new GPayAdapter(new GPay()));
        gPayStore.Checkout(149.99m);
    }
}

Output
=== Pay with PayPal ===
[Store] Processing checkout for $99.99...
[PayPalAdapter] Translating to PayPal...
[PayPal] Sending $99.99 via PayPal.
[Store] Payment done!

=== Pay with GPay ===
[Store] Processing checkout for $149.99...
[GPayAdapter] Translating to GPay...
[GPay] Paying $149.99 via Google Pay.
[Store] Payment done!

# Who Knows What
OnlineStore   →  only knows IPaymentProcessor
PayPalAdapter →  knows IPaymentProcessor + PayPal
GPayAdapter   →  knows IPaymentProcessor + GPay
PayPal        →  knows nothing about your app
GPay          →  knows nothing about your app


# Key Takeaway
OnlineStore never changed       — adding GPay did not touch store code
PayPal never changed            — no touching third party code
GPay never changed              — no touching third party code
Only new Adapters were written  — that is the only new code needed


# When to Use
You want to use existing class but its interface does not match
Integrating third party or legacy code you cannot modify
You want to swap providers without changing client code
Examples: payment gateways, legacy systems,
third party loggers, external APIs