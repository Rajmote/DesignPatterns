namespace DesignPatterns.Builder;

// DIRECTOR — encapsulates reusable "recipes" (fixed step sequences) so clients don't repeat them.
public class BurgerDirector
{
    public Burger CheeseBurger() =>
        new BurgerBuilder("medium").AddCheese().AddSauce().Build();

    public Burger BaconDeluxe() =>
        new BurgerBuilder("large").AddCheese().AddBacon().AddLettuce().AddSauce().Build();
}
