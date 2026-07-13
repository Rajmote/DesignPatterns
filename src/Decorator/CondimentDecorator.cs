namespace DesignPatterns.Decorator;

//Abstract Decorator
public abstract class CondimentDecorator : IBeverage
{
    protected IBeverage Beverage;

    protected CondimentDecorator(IBeverage beverage)
    {
        Beverage = beverage;
    }


    public abstract string GetDescription();

    public abstract decimal Cost();
}
