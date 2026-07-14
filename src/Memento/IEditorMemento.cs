namespace DesignPatterns.Memento;

// Opaque token — it has NO members, so a caretaker (History) can hold it but not read it.
// Only the TextEditor knows the real type hiding behind this interface.
public interface IEditorMemento { }
