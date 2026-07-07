namespace DesignPatterns.Strategy;

public class MallardDuck() : Duck(new FlyWithWings())
{
    public override void Display()
    {
        Console.WriteLine("I am a Mallard Duck");
    }
}