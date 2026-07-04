using System;
using System.Collections.Generic;

// ── SINGLETON ────────────────────────────────────────────────
public sealed class GameConfig
{
    private static readonly Lazy<GameConfig> _instance =
        new(() => new GameConfig());

    public static GameConfig Instance => _instance.Value;

    // Config state
    private readonly Dictionary<string, string> _settings = new();

    private GameConfig()
    {
        // Load default settings once
        _settings["difficulty"]  = "Medium";
        _settings["resolution"]  = "1920x1080";
        _settings["sound"]       = "On";
        _settings["language"]    = "English";
        Console.WriteLine("GameConfig created — only once!");
    }

    public string Get(string key) =>
        _settings.TryGetValue(key, out var val) ? val : "Not found";

    public void Set(string key, string value)
    {
        _settings[key] = value;
        Console.WriteLine($"Config updated: {key} = {value}");
    }

    public void PrintAll()
    {
        Console.WriteLine("\n── Current Settings ──────────────");
        foreach (var setting in _settings)
            Console.WriteLine($"  {setting.Key,-15} : {setting.Value}");
        Console.WriteLine("──────────────────────────────────\n");
    }
}