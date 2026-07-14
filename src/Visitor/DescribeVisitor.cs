public class DescribeVisitor : IShapeVisitor
{
    public void Visit(Circle c) => Console.WriteLine($"Circle r={c.Radius}");
    public void Visit(Square s) => Console.WriteLine($"Square s={s.Side}");
}
// foreach (var shape in shapes) shape.Accept(new DescribeVisitor());