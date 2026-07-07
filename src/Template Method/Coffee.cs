// ── COFFEE ────────────────────────────────────────────────────
// Fills in only the coffee-specific steps
public class Coffee : HotDrink
{
    // Coffee specific brewing
    protected override void Brew()
        => Console.WriteLine("Dripping coffee through filter...");

    // Coffee specific condiments
    protected override void AddCondiments()
        => Console.WriteLine("Adding sugar and milk...");
}