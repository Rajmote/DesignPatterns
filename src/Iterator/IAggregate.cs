namespace DesignPatterns.Iterator;
// 2. Aggregate interface
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}