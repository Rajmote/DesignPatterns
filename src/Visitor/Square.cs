namespace DesignPatterns.Visitor;

public class Square(double side) : IShape
{
    public double Side => side;
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);   // `this` is Square
}
