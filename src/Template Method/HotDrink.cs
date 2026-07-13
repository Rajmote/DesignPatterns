namespace DesignPatterns.TemplateMethod;

// ── ABSTRACT BASE CLASS ───────────────────────────────────────
// Defines the skeleton — the fixed order of steps
// Subclasses fill in only what is different
public abstract class HotDrink
{
    // THE TEMPLATE METHOD — final, nobody can change the order
    public void Prepare()
    {
        BoilWater();          // step 1 — same for all drinks
        Brew();               // step 2 — different per drink
        PourInCup();          // step 3 — same for all drinks
        AddCondiments();      // step 4 — different per drink
    }

    // Same for all drinks — implemented in base class
    private void BoilWater()
        => Console.WriteLine("Boiling water...");

    // Same for all drinks — implemented in base class
    private void PourInCup()
        => Console.WriteLine("Pouring into cup...");

    // Different per drink — subclasses must implement
    protected abstract void Brew();

    // Different per drink — subclasses must implement
    protected abstract void AddCondiments();
}

