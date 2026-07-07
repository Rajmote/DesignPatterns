# Template Method Pattern
---
## What is it?
Defines the **skeleton of an algorithm** in a base class and lets subclasses
fill in the specific steps — without changing the overall structure.
---
## Real-World Analogy
Making a hot drink — Tea or Coffee:
Both follow the same steps:
1. Boil water — same for both
2. Brew — DIFFERENT (tea steeps, coffee drips)
3. Pour in cup — same for both
4. Add condiments — DIFFERENT (tea adds lemon, coffee adds sugar)

The skeleton is the same — only specific steps differ

---
## Who Does What?
### HotDrink (Abstract Base Class)
- Defines the template method — the overall algorithm
- Implements steps that are the same for everyone
- Declares abstract methods for steps that are different
- Subclasses cannot change the order of steps
### Tea (Concrete Subclass)
- Fills in only tea-specific steps
- Brew — steeps the tea bag
- AddCondiments — adds lemon
### Coffee (Concrete Subclass)
- Fills in only coffee-specific steps
- Brew — drips through filter
- AddCondiments — adds sugar and milk
### Client
- Calls Prepare() on either Tea or Coffee
- Does not care which drink — same method call
- Algorithm order never changes
---
## The Flow
Client calls Prepare()
└── HotDrink.Prepare() runs in this order always:
├── Step 1: BoilWater() — base class handles
├── Step 2: Brew() — subclass handles
├── Step 3: PourInCup() — base class handles
└── Step 4: AddCondiments() — subclass handles

---
## The Code
```csharp
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
// ── TEA ───────────────────────────────────────────────────────
// Fills in only the tea-specific steps
public class Tea : HotDrink
{
    protected override void Brew()
        => Console.WriteLine("Steeping the tea bag...");
    protected override void AddCondiments()
        => Console.WriteLine("Adding lemon...");
}
// ── COFFEE ────────────────────────────────────────────────────
// Fills in only the coffee-specific steps
public class Coffee : HotDrink
{
    protected override void Brew()
        => Console.WriteLine("Dripping coffee through filter...");
    protected override void AddCondiments()
        => Console.WriteLine("Adding sugar and milk...");
}
// ── CLIENT ────────────────────────────────────────────────────
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Making Tea ===\n");
        HotDrink tea = new Tea();
        tea.Prepare();
        Console.WriteLine("\n=== Making Coffee ===\n");
        HotDrink coffee = new Coffee();
        coffee.Prepare();
    }
}

# Output
=== Making Tea ===
Boiling water...
Steeping the tea bag...
Pouring into cup...
Adding lemon...
=== Making Coffee ===
Boiling water...
Dripping coffee through filter...
Pouring into cup...
Adding sugar and milk...

# Hook Methods — Optional Steps
Hooks are optional steps subclasses can override but do not have to.

public abstract class HotDrink
{
    public void Prepare()
    {
        BoilWater();
        Brew();
        PourInCup();
        // Hook — only runs if subclass wants condiments
        if (CustomerWantsCondiments())
            AddCondiments();
    }
    private void BoilWater()  => Console.WriteLine("Boiling water...");
    private void PourInCup()  => Console.WriteLine("Pouring into cup...");
    protected abstract void Brew();
    protected abstract void AddCondiments();
    // Hook — subclass can override or leave as default
    // Default is true — condiments added unless overridden
    protected virtual bool CustomerWantsCondiments() => true;
}
// Coffee overrides hook — no condiments
public class Coffee : HotDrink
{
    protected override void Brew()
        => Console.WriteLine("Dripping coffee through filter...");
    protected override void AddCondiments()
        => Console.WriteLine("Adding sugar and milk...");
    // Override hook — skip condiments
    protected override bool CustomerWantsCondiments() => false;
}

# Abstract Method vs Hook

Abstract Method	Hook
Must override	Yes — subclass must implement	No — optional
Default behaviour	None	Has a default in base class
Use when	Step is always different	Step is sometimes different

# Who Knows What
HotDrink  →  knows the algorithm order only
Tea       →  knows tea-specific steps only
Coffee    →  knows coffee-specific steps only
Client    →  calls Prepare() — does not care which drink

# When to Use
Multiple classes follow the same steps but implement some differently
You want to control the order of steps and prevent changes
You want to avoid duplicate code across similar classes
Examples: data parsers, report generators, game loops,
beverage makers, build pipelines

# Key Takeaway
Without Template Method  →  Tea and Coffee both define ALL steps
                             duplicate code everywhere
With Template Method     →  Base class owns the order
                             Subclasses fill in only what differs
                             No duplicate code