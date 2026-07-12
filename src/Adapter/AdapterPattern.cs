namespace DesignPatterns.Adapter;
// Client
public class AdapterPattern
{
    public void Run()
    {
        Console.WriteLine("=== Pay with PayPal ===\n");
        var payPalStore = new OnlineStore(new PayPalAdapter(new PayPal()));
        payPalStore.Checkout(99.99m);

        Console.WriteLine("=== Pay with GPay ===\n");
        var gPayStore = new OnlineStore(new GPayAdapter(new GPay()));
        gPayStore.Checkout(149.99m);
    }
}