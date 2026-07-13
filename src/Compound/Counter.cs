namespace DesignPatterns.Compound;

// MODEL — holds state, shouts when it changes.  (Observer)
public class Counter
{
    public int Count { get; private set; }
    public event Action<int>? Changed;                 // observers subscribe here

    public void Add(int step) { Count += step; Changed?.Invoke(Count); }
}
