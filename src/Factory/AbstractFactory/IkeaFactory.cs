
// IKEA factory — creates only IKEA products - Concrete Factories
using DesignPatterns.AbstractFactory.ProductInterfaces;

namespace DesignPatterns.AbstractFactory.ConcreateProducts;

public class IkeaFactory : IFurnitureFactory
{
    public ISofa CreateSofa()   => new IkeaSofa();
    public IChair CreateChair() => new IkeaChair();
}