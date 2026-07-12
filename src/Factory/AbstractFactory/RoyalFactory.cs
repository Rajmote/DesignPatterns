
// Royal factory — creates only Royal products - Concrete Factories
using DesignPatterns.AbstractFactory.ProductInterfaces;

namespace DesignPatterns.AbstractFactory.ConcreateProducts;

public class RoyalFactory : IFurnitureFactory
{
    public ISofa CreateSofa()   => new RoyalSofa();
    public IChair CreateChair() => new RoyalChair();
}