namespace DesignPatterns.Builder;

// Client
public class BuilderPattern
{
    public void Run()
    {
        Burger burger = new BurgerBuilder("large")
      .AddCheese()
      .AddBacon()
      .AddSauce()
      .Build();
        // Burger { Size = large, Cheese = True, Bacon = True, Lettuce = False, Sauce = True }
    }
}
