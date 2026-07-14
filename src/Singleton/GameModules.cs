namespace DesignPatterns.Singleton;

// ── GAME MODULES (simulate different parts of your app) ──────
public class AudioManager
{
    public void Initialize()
    {
        // Gets the SAME GameConfig instance
        var config = GameConfig.Instance;
        Console.WriteLine($"[AudioManager] Sound is: {config.Get("sound")}");
    }
}

public class VideoManager
{
    public void Initialize()
    {
        // Gets the SAME GameConfig instance
        var config = GameConfig.Instance;
        Console.WriteLine($"[VideoManager] Resolution is: {config.Get("resolution")}");
    }
}

public class GameEngine
{
    public void Start()
    {
        // Gets the SAME GameConfig instance
        var config = GameConfig.Instance;
        Console.WriteLine($"[GameEngine] Difficulty is: {config.Get("difficulty")}");
    }
}
