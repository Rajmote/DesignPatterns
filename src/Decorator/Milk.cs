//Concrete Milk Decorators
public class Milk : CondimentDecorator
{
    public Milk(IBeverage beverage)
        : base(beverage)
    {
    }


    public override string GetDescription()
    {
        return Beverage.GetDescription() 
               + ", Milk";
    }


    public override decimal Cost()
    {
        return Beverage.Cost() + 20m;
    }
}