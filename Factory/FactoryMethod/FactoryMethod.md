## Factory Method Pattern
```markdown
# Factory Method Pattern
## What is it?
A method that creates objects but lets **subclasses decide which object to create**.
The parent class defines the structure, subclasses decide the details.
## Real-World Analogy
A logistics company ships goods. How they ship depends on the type:
- **Road logistics** → creates a Truck
- **Sea logistics**  → creates a Ship
## Step 1 — Product Interface
```csharp
public interface ITransport
{
    void Deliver();
}
Step 2 — Concrete Products
public class Truck : ITransport
{
    public void Deliver() => Console.WriteLine("Delivering by road in a Truck.");
}

public class Ship : ITransport
{
    public void Deliver() => Console.WriteLine("Delivering by sea in a Ship.");
}
Step 3 — Creator (base class with factory method)
public abstract class Logistics
{
    public abstract ITransport CreateTransport(); // factory method

    public void PlanDelivery()
    {
        ITransport transport = CreateTransport();
        Console.WriteLine("Planning delivery...");
        transport.Deliver();
    }
}
Step 4 — Concrete Creators
public class RoadLogistics : Logistics
{
    public override ITransport CreateTransport() => new Truck();
}

public class SeaLogistics : Logistics
{
    public override ITransport CreateTransport() => new Ship();
}
Usage
Logistics logistics = new RoadLogistics();
logistics.PlanDelivery();
// Planning delivery...
// Delivering by road in a Truck.

logistics = new SeaLogistics();
logistics.PlanDelivery();
// Planning delivery...
// Delivering by sea in a Ship.
Adding New Type — Zero Changes to Existing Code
public class Plane : ITransport
{
    public void Deliver() => Console.WriteLine("Delivering by air in a Plane.");
}

public class AirLogistics : Logistics
{
    public override ITransport CreateTransport() => new Plane();
}
Visual Structure
Logistics  (abstract creator)
    │
    ├── CreateTransport()  ← factory method
    │
    ├── RoadLogistics ──creates──► Truck
    ├── SeaLogistics  ──creates──► Ship
    └── AirLogistics  ──creates──► Plane
    
When to Use
You do not know ahead of time which object you need to create
You want subclasses to control what gets created
You want to add new types without changing existing code
Examples: document exporters (PDF/Word/Excel), notification senders, payment processors