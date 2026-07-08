// LEAF — a single file. Does the real work; no children.
using DesignPatterns.Composite;

public class FileItem : FileSystemItem
{
    private readonly long _bytes;
    public FileItem(string name, long bytes) : base(name) => _bytes = bytes;

    public override long GetSize() => _bytes;                       // just returns its own size
    public override void Print(string indent = "") => Console.WriteLine($"{indent}📄 {Name} ({_bytes} bytes)");
}