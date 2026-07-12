namespace DesignPatterns.Command.KitchenExample;

// ── INVOKER ───────────────────────────────────────────────────
// Waiter — takes orders and passes to kitchen
// Does not know what food is — only knows ICommand
public class Waiter
{
    // Keeps history of all placed orders
    private Stack<ICommand> _orderHistory = new Stack<ICommand>();

    // Place an order — execute and save to history
    public void PlaceOrder(ICommand command)
    {
        Console.WriteLine("[Waiter] Sending order to kitchen...");
        command.Execute();
        _orderHistory.Push(command);    // save for possible cancellation
    }

    // Cancel last order
    public void CancelLastOrder()
    {
        if (_orderHistory.Count == 0)
        {
            Console.WriteLine("[Waiter] No orders to cancel.");
            return;
        }

        var lastOrder = _orderHistory.Pop();   // get last order
        Console.WriteLine("[Waiter] Cancelling last order...");
        lastOrder.Undo();                      // cancel it
    }
}
