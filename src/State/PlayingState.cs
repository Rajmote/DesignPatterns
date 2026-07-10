public class PlayingState : IPlayerState
{
    public void Play(MediaPlayer p)  => Console.WriteLine("Already playing");
    public void Pause(MediaPlayer p) { Console.WriteLine("Pausing"); p.TransitionTo(new PausedState()); }
    public void Stop(MediaPlayer p)  { Console.WriteLine("Stopping"); p.TransitionTo(new StoppedState()); }
}