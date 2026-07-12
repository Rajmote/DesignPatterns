namespace DesignPatterns.Command.KitchenExample;

// ── CONCRETE COMMAND ──────────────────────────────────────────
// Wraps one food order as a command object
public class PlaceOrderCommand : ICommand
{
    private Kitchen _kitchen;    // receiver — does the real work
    private string _foodItem;    // what was ordered — needed for undo

    public PlaceOrderCommand(Kitchen kitchen, string foodItem)
    {
        _kitchen  = kitchen;
        _foodItem = foodItem;
    }

    // Place the order — tell kitchen to prepare
    public void Execute() => _kitchen.PrepareFood(_foodItem);

    // Cancel the order — tell kitchen to cancel
    public void Undo()    => _kitchen.CancelFood(_foodItem);
}