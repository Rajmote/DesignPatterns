namespace DesignPatterns.Builder;

// CLIENT — builds a burger with the fluent builder, and via a director's ready-made recipe.
public class BuilderPattern
{
    public void Run()
    {
        // 1. Fluent builder — name each optional part, then Build().
        Burger custom = new BurgerBuilder("large")
            .AddCheese()
            .AddBacon()
            .AddSauce()
            .Build();
        Console.WriteLine($"Custom : {custom}");

        // 2. Director — a reusable recipe, so the client doesn't repeat the steps.
        var director = new BurgerDirector();
        Console.WriteLine($"Recipe : {director.BaconDeluxe()}");
    }
}
