
// Royal factory — creates only Royal products - Concrete Factories

namespace DesignPatterns.Factory;

public class RoyalFactory : IFurnitureFactory
{
    public ISofa CreateSofa()   => new RoyalSofa();
    public IChair CreateChair() => new RoyalChair();
}