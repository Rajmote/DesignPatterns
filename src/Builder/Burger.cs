namespace DesignPatterns.Builder;

// PRODUCT — the complex object we want, immutable once built.
public record Burger(string Size, bool Cheese, bool Bacon, bool Lettuce, bool Sauce);
