namespace DesignPatterns.Decorator;

//Concrete Whipped Cream Decorator
public class WhippedCream : CondimentDecorator
{
    public WhippedCream(IBeverage beverage)
        : base(beverage)
    {
    }


    public override string GetDescription()
    {
        return Beverage.GetDescription()
               + ", Whipped Cream";
    }


    public override decimal Cost()
    {
        return Beverage.Cost() + 30m;
    }
}