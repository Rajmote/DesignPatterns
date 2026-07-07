# Abstract Factory Pattern

## What is it?
A factory that creates **families of related objects** without specifying their exact classes.
Think of it as a **factory of factories**.

## Real-World Analogy
- **IKEA**  — makes Modern sofa, Modern chair
- **Royal** — makes Classic sofa, Classic chair

You pick a brand (factory) and it gives you all matching furniture.
You never mix IKEA sofa with Royal chair.

## Step 1 — Product Interfaces

```csharp
public interface ISofa
{
    void Describe();
}

public interface IChair
{
    void Describe();
}

// IKEA products
public class IkeaSofa : ISofa
{
    public void Describe() => Console.WriteLine("IKEA Modern Sofa");
}

public class IkeaChair : IChair
{
    public void Describe() => Console.WriteLine("IKEA Modern Chair");
}

// Royal products
public class RoyalSofa : ISofa
{
    public void Describe() => Console.WriteLine("Royal Classic Sofa");
}

public class RoyalChair : IChair
{
    public void Describe() => Console.WriteLine("Royal Classic Chair");
}

public interface IFurnitureFactory
{
    ISofa CreateSofa();
    IChair CreateChair();
}

public class IkeaFactory : IFurnitureFactory
{
    public ISofa CreateSofa()   => new IkeaSofa();
    public IChair CreateChair() => new IkeaChair();
}

public class RoyalFactory : IFurnitureFactory
{
    public ISofa CreateSofa()   => new RoyalSofa();
    public IChair CreateChair() => new RoyalChair();
}

public class Room
{
    private readonly ISofa _sofa;
    private readonly IChair _chair;

    public Room(IFurnitureFactory factory)
    {
        _sofa  = factory.CreateSofa();
        _chair = factory.CreateChair();
    }

    public void Describe()
    {
        _sofa.Describe();
        _chair.Describe();
    }
}

var room1 = new Room(new IkeaFactory());
room1.Describe();
// IKEA Modern Sofa
// IKEA Modern Chair

var room2 = new Room(new RoyalFactory());
room2.Describe();
// Royal Classic Sofa
// Royal Classic Chair

IFurnitureFactory  (abstract factory)
    │
    ├── IkeaFactory  ──creates──►  IkeaSofa,  IkeaChair
    │
    └── RoyalFactory ──creates──►  RoyalSofa, RoyalChair

Room only talks to IFurnitureFactory — never to concrete classes

When to Use
You need families of related objects that must be used together
You want to switch the whole family at once
You want client code independent of concrete classes
Examples: UI themes (Dark/Light), database providers, payment gateways