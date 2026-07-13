namespace DesignPatterns.Factory;

public class Ship : ITransport
{
    public void Deliver() => Console.WriteLine("Delivering by sea in a Ship.");
}
