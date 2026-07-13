namespace DesignPatterns.Factory;

public class Plane : ITransport
{
    public void Deliver() => Console.WriteLine("Delivering by air in a Plane.");
}
