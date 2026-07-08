namespace DesignPatterns.Iterator;
public class IteratorPattern
{
    public void Run()
    {
        var shelf = new BookShelf(3);
        shelf.Add("Clean Code");
        shelf.Add("GoF Design Patterns");
        shelf.Add("The Pragmatic Programmer");

        IIterator<string> it = shelf.CreateIterator();
        while (it.HasNext())
            Console.WriteLine(it.Next());
    }
}