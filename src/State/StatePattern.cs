namespace DesignPatterns.State;

public class StatePattern
{
    public void Run()
    {
        var player = new MediaPlayer();
        player.Play();    // Starting from beginning  → now PlayingState
        player.Pause();   // Pausing                  → now PausedState
        player.Pause();   // Already paused
        player.Play();    // Resuming                 → now PlayingState
        player.Stop();    // Stopping                 → now StoppedState
        player.Pause();   // Can't pause — already stopped
    }
}