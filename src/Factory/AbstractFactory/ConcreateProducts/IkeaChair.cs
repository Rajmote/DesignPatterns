using DesignPatterns.AbstractFactory.ProductInterfaces;

namespace DesignPatterns.AbstractFactory.ConcreateProducts;

public class IkeaChair : IChair
{
    public void Describe() => Console.WriteLine("IKEA Modern Chair");
}