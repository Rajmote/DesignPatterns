namespace DesignPatterns.Visitor;

// A concrete operation: total up the area.
public class AreaCalculator : IShapeVisitor
{
    public double Total { get; private set; }
    public void Visit(Circle circle) => Total += Math.PI * circle.Radius * circle.Radius;
    public void Visit(Square square) => Total += square.Side * square.Side;
}
