using DesignPatterns.AbstractFactory.ProductInterfaces;

namespace DesignPatterns.AbstractFactory.ConcreateProducts;

public class RoyalSofa : ISofa
{
    public void Describe() => Console.WriteLine("Royal Classic Sofa");
}