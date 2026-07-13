namespace DesignPatterns.Bridge;

public class Tv : IDevice
{
    public string Name => "TV";
    public void SetPower(bool on) => Console.WriteLine($"TV power {(on ? "on" : "off")}");
    public void SetVolume(int percent) => Console.WriteLine($"TV volume {percent}%");
}
