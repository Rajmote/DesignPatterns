namespace DesignPatterns.TemplateMethod;

// ── TEA ───────────────────────────────────────────────────────
// Fills in only the tea-specific steps
public class Tea : HotDrink
{
    // Tea specific brewing
    protected override void Brew()
        => Console.WriteLine("Steeping the tea bag...");

    // Tea specific condiments
    protected override void AddCondiments()
        => Console.WriteLine("Adding lemon...");
}
