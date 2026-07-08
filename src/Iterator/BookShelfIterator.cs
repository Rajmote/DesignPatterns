namespace DesignPatterns.Iterator;
// 4. Concrete iterator — holds the position, walks the shelf
public class BookShelfIterator : IIterator<string>
{
    private readonly BookShelf _shelf;
    private int _index = 0;                 // <-- the cursor lives HERE

    public BookShelfIterator(BookShelf shelf) => _shelf = shelf;

    public bool HasNext() => _index < _shelf.Count;
    public string Next() => _shelf.GetAt(_index++);
}