namespace DesignPatterns.Decorator;

//Concrete Sugar Decorator
public class Sugar : CondimentDecorator
{
    public Sugar(IBeverage beverage)
        : base(beverage)
    {
    }


    public override string GetDescription()
    {
        return Beverage.GetDescription()
               + ", Sugar";
    }


    public override decimal Cost()
    {
        return Beverage.Cost() + 10m;
    }
}
