namespace DesignPatterns.Singleton;
public class SingletonPattern
{
    public void Run()
    {
      Console.WriteLine("=== Game Starting ===\n");

        // First access — instance created here
        GameConfig.Instance.PrintAll();

        // Different parts of app access config
        var audio = new AudioManager();
        var video = new VideoManager();
        var engine = new GameEngine();

        audio.Initialize();
        video.Initialize();
        engine.Start();

        // Change a setting from one place
        Console.WriteLine("\n── Player changes difficulty ──");
        GameConfig.Instance.Set("difficulty", "Hard");
        GameConfig.Instance.Set("sound", "Off");

        // All parts of app see the updated config — same instance
        Console.WriteLine("\n── After change ──");
        audio.Initialize();
        engine.Start();

        // Prove it is the same instance
        Console.WriteLine("\n── Proving same instance ──");
        var ref1 = GameConfig.Instance;
        var ref2 = GameConfig.Instance;
        var ref3 = GameConfig.Instance;
        Console.WriteLine($"ref1 == ref2 : {ReferenceEquals(ref1, ref2)}");
        Console.WriteLine($"ref2 == ref3 : {ReferenceEquals(ref2, ref3)}");

        GameConfig.Instance.PrintAll();
    }
}