namespace DesignPatterns.Factory;

public class Truck : ITransport
{
    public void Deliver() => Console.WriteLine("Delivering by road in a Truck.");
}