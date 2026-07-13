namespace DesignPatterns.Command.KitchenExample;

// ── CLIENT ────────────────────────────────────────────────────
// Customer placing orders at the restaurant
public static class KitchenClient
{
    public static void Run()
    {
        // Create receiver
        var kitchen = new Kitchen();

        // Create invoker
        var waiter = new Waiter();

        // Customer places orders
        Console.WriteLine("=== Customer Orders ===\n");

        var order1 = new PlaceOrderCommand(kitchen, "Burger");
        var order2 = new PlaceOrderCommand(kitchen, "Pizza");
        var order3 = new PlaceOrderCommand(kitchen, "Pasta");

        waiter.PlaceOrder(order1);    // Burger ordered
        waiter.PlaceOrder(order2);    // Pizza ordered
        waiter.PlaceOrder(order3);    // Pasta ordered

        // Customer cancels last order
        Console.WriteLine("\n=== Customer Cancels Last Order ===\n");
        waiter.CancelLastOrder();     // Pasta cancelled

        // Customer cancels again
        Console.WriteLine("\n=== Customer Cancels Again ===\n");
        waiter.CancelLastOrder();     // Pizza cancelled

        // No more cancellations
        Console.WriteLine("\n=== Try Cancel When Nothing Left ===\n");
        waiter.CancelLastOrder();
        waiter.CancelLastOrder();
        waiter.CancelLastOrder();     // Nothing to cancel
    }
}
