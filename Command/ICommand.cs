// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}


// No Command — Head First uses this as default slot value
// instead of checking for null
public class NoCommand : ICommand
{
    public void Execute() => Console.WriteLine("No command assigned to this slot");
    public void Undo()    => Console.WriteLine("Nothing to undo");
}









