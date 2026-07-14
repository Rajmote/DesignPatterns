// FLYWEIGHT — intrinsic (shared, heavy) state. Immutable, reused across many trees.
public class TreeType
{
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }   // imagine this is large

    public TreeType(string name, string color, string texture) =>
        (Name, Color, Texture) = (name, color, texture);

    // x,y are EXTRINSIC — passed in, not stored.
    public void Draw(int x, int y) => Console.WriteLine($"Drawing {Color} {Name} at ({x},{y})");
}