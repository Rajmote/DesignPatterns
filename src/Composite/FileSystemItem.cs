namespace DesignPatterns.Composite;
// COMPONENT — the shared interface. Client code only ever talks to this.
public abstract class FileSystemItem
{
    public string Name { get; }
    protected FileSystemItem(string name) => Name = name;

    public abstract long GetSize();          // both leaf and composite answer this
    public abstract void Print(string indent = "");
}