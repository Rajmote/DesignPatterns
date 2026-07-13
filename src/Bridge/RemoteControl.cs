namespace DesignPatterns.Bridge;

// ABSTRACTION — holds a reference to the implementor (THE BRIDGE) and delegates to it.
public class RemoteControl
{
    protected readonly IDevice Device;          // ← the bridge (has-a)
    public RemoteControl(IDevice device) => Device = device;

    public void TogglePower() => Device.SetPower(true);
    public void SetVolume(int percent) => Device.SetVolume(percent);
}
