namespace DesignPatterns.State;

public class StoppedState : IPlayerState
{
    public void Play(MediaPlayer p) { Console.WriteLine("Starting from beginning"); p.TransitionTo(new PlayingState()); }
    public void Pause(MediaPlayer p) => Console.WriteLine("Can't pause — already stopped");
    public void Stop(MediaPlayer p) => Console.WriteLine("Already stopped");
}
