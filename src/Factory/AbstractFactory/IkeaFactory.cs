
// IKEA factory — creates only IKEA products - Concrete Factories

namespace DesignPatterns.Factory;

public class IkeaFactory : IFurnitureFactory
{
    public ISofa CreateSofa() => new IkeaSofa();
    public IChair CreateChair() => new IkeaChair();
}
