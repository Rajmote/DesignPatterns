namespace DesignPatterns.Factory;

// Parent class — defines the factory method
public abstract class Logistics
{
    // THE factory method — subclasses must override this
    public abstract ITransport CreateTransport();

    // Business logic — uses the factory method
    // Does not know Truck or Ship — only ITransport
    public void PlanDelivery()
    {
        ITransport transport = CreateTransport();
        Console.WriteLine("Planning delivery...");
        transport.Deliver();
    }
}
