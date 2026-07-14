namespace DesignPatterns.Builder;

// BUILDER — collects choices step by step, then produces the product.

public class BurgerBuilder
{
    private readonly string _size;                       // required → constructor
    private bool _cheese, _bacon, _lettuce, _sauce;      // optional → steps

    public BurgerBuilder(string size) => _size = size;

    public BurgerBuilder AddCheese() { _cheese = true; return this; }   // return this
    public BurgerBuilder AddBacon() { _bacon = true; return this; }   // → calls chain
    public BurgerBuilder AddLettuce() { _lettuce = true; return this; }
    public BurgerBuilder AddSauce() { _sauce = true; return this; }

    public Burger Build() => new(_size, _cheese, _bacon, _lettuce, _sauce);
}
