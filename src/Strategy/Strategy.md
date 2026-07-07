Strategy Pattern
# What is it?
Define a family of algorithms, put each in a separate class,
and make them interchangeable at runtime without changing the code that uses them.

# Key Participants
Strategy interface — defines the algorithm contract
Concrete strategies — each implements the algorithm differently
Context — holds a reference to a strategy and calls it

# Simple Example

public interface ISortStrategy
{
    void Sort(List<int> data);
}

public class BubbleSort : ISortStrategy
{
    public void Sort(List<int> data) => Console.WriteLine("Sorting using Bubble Sort");
}

public class QuickSort : ISortStrategy
{
    public void Sort(List<int> data) => Console.WriteLine("Sorting using Quick Sort");
}

public class Sorter
{
    private ISortStrategy _strategy;

    public Sorter(ISortStrategy strategy) => _strategy = strategy;

    public void SetStrategy(ISortStrategy strategy) => _strategy = strategy;

    public void Sort(List<int> data) => _strategy.Sort(data);
}

var sorter = new Sorter(new BubbleSort());
sorter.Sort(data);

sorter.SetStrategy(new QuickSort());
sorter.Sort(data);

# When to Use
You have multiple ways to do the same thing
You want to switch algorithms at runtime
You want to avoid large if/else or switch blocks
Examples: payment methods, sorting, discount calculations, export formats

# Key Difference
Observer	Strategy
Purpose	Notify many objects when state changes	Swap algorithms at runtime
Relationship	One publisher → many subscribers	One context → one strategy at a time
Focus	Communication between objects	How an operation is performed