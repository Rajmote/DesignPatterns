namespace DesignPatterns.State;

// STATE interface — the actions the player supports.
public interface IPlayerState
{
    void Play(MediaPlayer player);
    void Pause(MediaPlayer player);
    void Stop(MediaPlayer player);
}
