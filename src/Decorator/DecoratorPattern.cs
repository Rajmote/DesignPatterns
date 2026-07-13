namespace DesignPatterns.Decorator;

// TO DO: Implement the Decorator Pattern example here
public class DecoratorPattern
{
    public void Run()
    {
        IBeverage coffee = new Espresso();

        coffee = new Milk(coffee);

        coffee = new Sugar(coffee);

        coffee = new WhippedCream(coffee);

        Console.WriteLine(
            coffee.GetDescription()
        );

        Console.WriteLine(
            $"Total Cost: {coffee.Cost()}"
        );
    }
}
