namespace DesignPatterns.Factory;

// Decides to create a Ship - Concrete Creator
public class SeaLogistics : Logistics
{
    public override ITransport CreateTransport() => new Ship();
}
