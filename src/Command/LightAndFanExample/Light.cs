namespace DesignPatterns.Command.LightAndFanExample;

// Receiver 1 — Light
public class Light
{
    private string _location;
    public Light(string location) => _location = location;

    public void On()  => Console.WriteLine($"{_location} light is on");
    public void Off() => Console.WriteLine($"{_location} light is off");
}
