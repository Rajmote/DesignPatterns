public class Circle(double radius) : IShape
{
    public double Radius => radius;
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);   // `this` is Circle
}