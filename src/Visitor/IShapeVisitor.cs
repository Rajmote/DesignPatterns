// VISITOR — one method per shape type
public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Square square);
}