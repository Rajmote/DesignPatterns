using DesignPatterns.AbstractFactory.ProductInterfaces;

namespace DesignPatterns.AbstractFactory.ConcreateProducts;
public class IkeaSofa : ISofa
{
    public void Describe() => Console.WriteLine("IKEA Modern Sofa");
}