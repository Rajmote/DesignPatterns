namespace DesignPatterns.Memento;

// CARETAKER — keeps history, never inspects a memento.
public class History
{
    private readonly Stack<IEditorMemento> _states = new();
    public void Push(IEditorMemento m) => _states.Push(m);
    public IEditorMemento? Pop() => _states.Count > 0 ? _states.Pop() : null;
}
