public class PausedState : IPlayerState
{
    public void Play(MediaPlayer p)  { Console.WriteLine("Resuming"); p.TransitionTo(new PlayingState()); }
    public void Pause(MediaPlayer p) => Console.WriteLine("Already paused");
    public void Stop(MediaPlayer p)  { Console.WriteLine("Stopping"); p.TransitionTo(new StoppedState()); }
}