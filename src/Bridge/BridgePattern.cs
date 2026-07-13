namespace DesignPatterns.Bridge;

// Client
public class BridgePattern
{
    public void Run()
    {
        RemoteControl tvRemote = new RemoteControl(new Tv());
        tvRemote.TogglePower();      // TV power on
        tvRemote.SetVolume(30);      // TV volume 30%

        var radioRemote = new AdvancedRemote(new Radio());
        radioRemote.TogglePower();   // Radio power on
        radioRemote.Mute();          // Muting Radio  →  Radio volume 0%
    }
}
