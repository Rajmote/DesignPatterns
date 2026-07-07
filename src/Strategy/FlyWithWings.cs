namespace DesignPatterns.Strategy;

public class FlyWithWings:IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("I am flying with wings");
    }
}