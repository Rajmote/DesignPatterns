namespace DesignPatterns.Iterator;
// 1. Iterator interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}
