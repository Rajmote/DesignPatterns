namespace DesignPatterns.Decorator;

//Concrete Component
public class Espresso : IBeverage
{
    public string GetDescription()
    {
        return "Espresso";
    }

    public decimal Cost()
    {
        return 100m;
    }
}
