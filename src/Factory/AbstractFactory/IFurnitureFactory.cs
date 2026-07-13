
namespace DesignPatterns.Factory;

// The factory contract - Abstract Factory Interface
public interface IFurnitureFactory
{
    ISofa CreateSofa();
    IChair CreateChair();
}