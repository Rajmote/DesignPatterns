// Opaque token — no members, so a caretaker can hold it but not read it.
public interface IEditorMemento { }


public record EditorState(string Content, int CursorPos);   // the memento
// save:    var snap = new EditorState(_content, _cursor);
// restore: (_content, _cursor) = (snap.Content, snap.CursorPos);
// tweak a copy: snap with { CursorPos = 0 };