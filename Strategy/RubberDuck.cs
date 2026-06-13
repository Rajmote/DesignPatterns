namespace DesignPatterns.Strategy;

public class RubberDuck() : Duck(new FlyNoWay())
{
    public override void Display()
    {
        Console.WriteLine("I am a Rubber Duck");
    }
}