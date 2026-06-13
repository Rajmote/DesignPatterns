namespace DesignPatterns.Strategy;

public class Strategy
{
    public void Run()
    {
        var mallardDuck = new MallardDuck(); // Notice that the duck is flying by default. We have initialized it with a FlyWithWings strategy.
        mallardDuck.Display();
        mallardDuck.PerformFly();// Notice that the behaviour changes. It calls the FlyWithWings strategy's Fly() method.
        mallardDuck.Swim();
        Console.WriteLine();
        
        var rubberDuck = new RubberDuck(); // Notice that the duck is not flying by default. We have initialized it with a FlyNoWay strategy.
        rubberDuck.Display();
        rubberDuck.PerformFly(); // Notice that the behaviour changes. It calls the FlyNoWay strategy's Fly() method.
        rubberDuck.Swim();
        Console.WriteLine();
        
        Console.WriteLine("Adding rocket power to rubber duck...");
        rubberDuck.SetFlyBehaviour(new FlyWithWings()); // We can change the fly behaviour at runtime.
        rubberDuck.PerformFly(); // Notice that the behaviour changes.
        
        // Note: - This strategy is nothing but encapsulation of the behaviour. In our example, we have changed the behaviour of the duck at runtime.
        
        
    }
}