using System.Collections;

namespace DesignPatterns.Enumerator;

public class BookShelf : IEnumerable<string>
{
    private readonly string[] _books;
    private int _count = 0;

    public BookShelf(int max) => _books = new string[max];

    public void Add(string book) => _books[_count++] = book;
    public int Count => _count;

    // This ONE method replaces CreateIterator() + the entire BookShelfIterator class.
    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
            yield return _books[i];        // compiler generates the cursor + MoveNext/Current
    }

    // Required non-generic version (legacy); just delegate to the generic one.
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
