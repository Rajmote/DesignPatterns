using DesignPatterns.AbstractFactory.ProductInterfaces;

namespace DesignPatterns.AbstractFactory.ConcreateProducts;

public class RoyalChair : IChair
{
    public void Describe() => Console.WriteLine("Royal Classic Chair");
}