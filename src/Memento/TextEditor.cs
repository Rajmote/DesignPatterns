namespace DesignPatterns.Memento;

public class TextEditor
{
    private string _content = "";

    public void Type(string text) => _content += text;
    public void Show() => Console.WriteLine($"Content: \"{_content}\"");

    public IEditorMemento Save() => new Memento(_content);          // snapshot

    public void Restore(IEditorMemento memento)
    {
        if (memento is not Memento m)
            throw new ArgumentException("Unknown memento", nameof(memento));
        _content = m.Content;                                       // only we can read it
    }

    // MEMENTO — private & nested: only TextEditor can see .Content.
    private sealed class Memento(string content) : IEditorMemento
    {
        public string Content { get; } = content;
    }
}
