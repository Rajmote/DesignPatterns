
namespace DesignPatterns.Factory;
// Client Code (uses the factory)
public class Room
{
    private readonly ISofa _sofa;
    private readonly IChair _chair;

    // Room does not know IKEA or Royal — only knows the factory
    public Room(IFurnitureFactory factory)
    {
        _sofa = factory.CreateSofa();
        _chair = factory.CreateChair();
    }

    public void Describe()
    {
        _sofa.Describe();
        _chair.Describe();
    }
}
