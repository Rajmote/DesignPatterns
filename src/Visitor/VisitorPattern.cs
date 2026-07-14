namespace DesignPatterns.Visitor;

// CLIENT — runs two different operations over the same shapes, without changing the shape classes.
public class VisitorPattern
{
    public void Run()
    {
        IShape[] shapes = [new Circle(2), new Square(3), new Circle(1)];

        // Operation 1: describe each shape.
        var describe = new DescribeVisitor();
        foreach (var shape in shapes)
            shape.Accept(describe);

        // Operation 2: total the area — a brand-new operation, and Circle/Square never changed.
        var area = new AreaCalculator();
        foreach (var shape in shapes)
            shape.Accept(area);

        Console.WriteLine($"Total area: {area.Total:F2}");   // 24.71  (π·4 + 9 + π·1)
    }
}
