// ELEMENTS
public interface IShape
{
    void Accept(IShapeVisitor visitor);
}