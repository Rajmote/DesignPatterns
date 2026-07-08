namespace DesignPatterns.Iterator;
// 3. Concrete aggregate — internally an array (could be anything)
public class BookShelf : IAggregate<string>
{
    private readonly string[] _books;
    private int _count = 0;

    public BookShelf(int max) => _books = new string[max];

    public void Add(string book) => _books[_count++] = book;
    public int Count => _count;
    public string GetAt(int index) => _books[index];

    public IIterator<string> CreateIterator() => new BookShelfIterator(this);
}