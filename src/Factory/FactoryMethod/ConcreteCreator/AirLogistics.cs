namespace DesignPatterns.Factory;

// Decides to create a Plane - Concrete Creator
public class AirLogistics : Logistics
{
    public override ITransport CreateTransport() => new Plane();
}
