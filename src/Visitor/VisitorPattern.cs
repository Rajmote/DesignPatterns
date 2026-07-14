namespace DesignPatterns.Visitor;

// ── CLIENT ────────────────────────────────────────────────────
public class VisitorPattern
{
    public void Run()
    {
        IShape[] shapes = [new Circle(2), new Square(3), new Circle(1)];

        var area = new AreaCalculator();
        foreach (var shape in shapes)
            shape.Accept(area);        // each shape bounces to the right Visit overload

        Console.WriteLine($"Total area: {area.Total:F2}");
        // Total area: 24.71     (π·4 + 9 + π·1)
    }
}
