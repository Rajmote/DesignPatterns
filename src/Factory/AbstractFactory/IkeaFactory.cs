// IKEA factory — creates only IKEA products - Concrete Factories
public class IkeaFactory : IFurnitureFactory
{
    public ISofa CreateSofa()   => new IkeaSofa();
    public IChair CreateChair() => new IkeaChair();
}