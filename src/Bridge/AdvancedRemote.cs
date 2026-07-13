namespace DesignPatterns.Bridge;

// REFINED ABSTRACTION — new feature, works with ANY device automatically.
public class AdvancedRemote : RemoteControl
{
    public AdvancedRemote(IDevice device) : base(device) { }

    public void Mute()
    {
        Console.WriteLine($"Muting {Device.Name}");
        Device.SetVolume(0);
    }
}
