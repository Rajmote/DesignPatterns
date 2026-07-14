// CONTEXT — one per tree. Light: extrinsic state + a pointer to the shared flyweight.
public class Tree(int x, int y, TreeType type)
{
    public void Draw() => type.Draw(x, y);
}