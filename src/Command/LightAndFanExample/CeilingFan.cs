namespace DesignPatterns.Command.LightAndFanExample;

// Receiver 2 — CeilingFan
public class CeilingFan
{
    private string _location;
    public CeilingFan(string location) => _location = location;

    public void High()   => Console.WriteLine($"{_location} ceiling fan is on high");
    public void Medium() => Console.WriteLine($"{_location} ceiling fan is on medium");
    public void Off()    => Console.WriteLine($"{_location} ceiling fan is off");
}