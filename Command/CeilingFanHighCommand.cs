// Concrete Commands — CeilingFan
public class CeilingFanHighCommand : ICommand
{
    private CeilingFan _fan;
    public CeilingFanHighCommand(CeilingFan fan) => _fan = fan;
    public void Execute() => _fan.High();
    public void Undo()    => _fan.Off();
}