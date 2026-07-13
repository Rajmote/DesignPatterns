namespace DesignPatterns.Bridge;

public class Radio : IDevice
{
    public string Name => "Radio";
    public void SetPower(bool on) => Console.WriteLine($"Radio power {(on ? "on" : "off")}");
    public void SetVolume(int percent) => Console.WriteLine($"Radio volume {percent}%");
}
