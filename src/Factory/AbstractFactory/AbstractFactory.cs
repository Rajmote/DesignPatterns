
namespace DesignPatterns.Factory;
public class AbstractFactory
{
    public void Run()
    {
        // Choose IKEA
        var room1 = new Room(new IkeaFactory());
        room1.Describe();
        // IKEA Modern Sofa
        // IKEA Modern Chair

        // Switch to Royal — zero changes to Room class
        var room2 = new Room(new RoyalFactory());
        room2.Describe();
        // Royal Classic Sofa
        // Royal Classic Chair

    }
}