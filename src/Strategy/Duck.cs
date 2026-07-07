namespace DesignPatterns.Strategy;

public abstract class Duck
{
    // Reference to the strategy object.
    // Instead of implementing flying logic here,
    // Duck delegates the work to an IFlyBehaviour.
    private IFlyBehaviour _flyBehaviour;

    // Constructor receives a flying strategy.
    // This is called by derived classes (MallardDuck, RubberDuck, etc.)
    // to configure the initial flying behavior.
    protected Duck(IFlyBehaviour flyBehaviour)
    {
        _flyBehaviour = flyBehaviour;
    }
    
    // Delegates flying to the current strategy object.
    // Duck itself doesn't know HOW flying is implemented.
    // It only knows that the strategy has a Fly() method.
    public void PerformFly()
    {
        _flyBehaviour.Fly();
    }
    
    // Allows changing the strategy at runtime.
    // Example:
    // duck.SetFlyBehaviour(new FlyWithWings());
    // duck.SetFlyBehaviour(new FlyNoWay());
    public void SetFlyBehaviour(IFlyBehaviour flyBehaviour)
    {
        _flyBehaviour = flyBehaviour;
    }
    
    // Each concrete duck must provide its own display logic.
    // For example,
    // MallardDuck => "I am a Mallard Duck"
    // RubberDuck => "I am a Rubber Duck"
    public abstract void Display();
    
    // Common behavior shared by all ducks.
    // Since every duck can swim, it is implemented in the base class.
    public void Swim()
    {
        Console.WriteLine("All ducks float.");
    }
    
}