namespace DesignPatterns.Compound;

// VIEW — listens to the model and prints.  (Observer subscriber)
public class Display
{
    public Display(Counter model) => model.Changed += n => Console.WriteLine($"Count = {n}");
}
