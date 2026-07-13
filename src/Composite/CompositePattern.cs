namespace DesignPatterns.Composite;

public class CompositePattern
{
    public void Run()
    {
        var root = new FolderItem("project");
        root.Add(new FileItem("README.md", 2_000));

        var src = new FolderItem("src");
        src.Add(new FileItem("Program.cs", 5_000));
        src.Add(new FileItem("Helpers.cs", 3_000));
        root.Add(src);                                 // a folder inside a folder — any depth

        root.Print();
        Console.WriteLine($"Total: {root.GetSize()} bytes");   // 10,000 — recurses the whole tree
    }
}
