namespace DesignPatterns.Enumerator;
public class EnumeratorPattern
{
    public void Run()
    {
        var shelf = new BookShelf(3);
        shelf.Add("Clean Code");
        shelf.Add("GoF Design Patterns");
        shelf.Add("The Pragmatic Programmer");

        foreach (var book in shelf)          // Iterator pattern, built in
            Console.WriteLine(book);

        // Bonus: you now get all of LINQ for free
        var first = shelf.First();
        var count = shelf.Count();
        bool has = shelf.Any(b => b.Contains("GoF"));
    }
}