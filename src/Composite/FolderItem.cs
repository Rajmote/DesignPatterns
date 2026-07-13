// COMPOSITE — a folder. Holds children and delegates to them.
using DesignPatterns.Composite;

public class FolderItem : FileSystemItem
{
    private readonly List<FileSystemItem> _children = new();
    public FolderItem(string name) : base(name) { }

    public void Add(FileSystemItem item) => _children.Add(item);   // build the tree
    public void Remove(FileSystemItem item) => _children.Remove(item);

    // The key move: delegate the SAME operation to every child, whatever it is.
    public override long GetSize() => _children.Sum(c => c.GetSize());

    public override void Print(string indent = "")
    {
        Console.WriteLine($"{indent}📁 {Name}/");
        foreach (var child in _children)
            child.Print(indent + "  ");        // recursion falls out naturally
    }
}
