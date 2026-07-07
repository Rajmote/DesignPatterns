// Invoker — Remote Control with 7 slots
public class RemoteControl
{
    private ICommand[] _onCommands  = new ICommand[7];
    private ICommand[] _offCommands = new ICommand[7];
    private ICommand   _lastCommand;

    public RemoteControl()
    {
        // Fill all slots with NoCommand — no null checks needed
        for (int i = 0; i < 7; i++)
        {
            _onCommands[i]  = new NoCommand();
            _offCommands[i] = new NoCommand();
        }
        _lastCommand = new NoCommand();
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        _onCommands[slot]  = onCommand;
        _offCommands[slot] = offCommand;
    }

    public void OnButtonPressed(int slot)
    {
        _onCommands[slot].Execute();
        _lastCommand = _onCommands[slot];
    }

    public void OffButtonPressed(int slot)
    {
        _offCommands[slot].Execute();
        _lastCommand = _offCommands[slot];
    }

    public void UndoButtonPressed()
    {
        Console.WriteLine("-- Undo --");
        _lastCommand.Undo();
    }
}