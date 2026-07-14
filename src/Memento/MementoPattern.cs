namespace DesignPatterns.Memento;

public class MementoPattern
{
    public void Run()
    {
        var editor = new TextEditor();
        var history = new History();

        editor.Type("Hello");
        history.Push(editor.Save());        // checkpoint 1

        editor.Type(", world");
        history.Push(editor.Save());        // checkpoint 2

        editor.Type("!!! oops");
        editor.Show();                      // "Hello, world!!! oops"

        editor.Restore(history.Pop()!);     // undo → checkpoint 2
        editor.Show();                      // "Hello, world"

        editor.Restore(history.Pop()!);     // undo → checkpoint 1
        editor.Show();                      // "Hello"

    }
}
