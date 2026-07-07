// Decides to create a Truck - Concrete Creator
public class RoadLogistics : Logistics
{
    public override ITransport CreateTransport() => new Truck();
}