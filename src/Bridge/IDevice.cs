namespace DesignPatterns.Bridge;

// IMPLEMENTOR — low-level operations.
public interface IDevice
{
    string Name { get; }
    void SetPower(bool on);
    void SetVolume(int percent);
}
