namespace DesignPatterns.Command.KitchenExample;

// ── RECEIVER ──────────────────────────────────────────────────
// Kitchen does the actual work — prepare or cancel food
public class Kitchen
{
    // Prepares the food item
    public void PrepareFood(string item)
        => Console.WriteLine($"[Kitchen] Preparing: {item}");

    // Cancels the food item
    public void CancelFood(string item)
        => Console.WriteLine($"[Kitchen] Cancelled: {item}");
}
