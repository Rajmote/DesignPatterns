namespace DesignPatterns.State;

// CONTEXT — holds the current state and delegates to it. No if/else anywhere.
public class MediaPlayer
{
    public IPlayerState State { get; private set; }

    public MediaPlayer() => State = new StoppedState();   // initial state

    public void TransitionTo(IPlayerState next)
    {
        Console.WriteLine($"  → now {next.GetType().Name}");
        State = next;
    }

    // Every method is a one-liner: hand off to the current state.
    public void Play() => State.Play(this);
    public void Pause() => State.Pause(this);
    public void Stop() => State.Stop(this);
}
