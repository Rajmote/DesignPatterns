// FLYWEIGHT FACTORY — creates each TreeType once, then reuses it.
public static class TreeTypeFactory
{
    private static readonly Dictionary<string, TreeType> s_types = new();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        var key = $"{name}|{color}|{texture}";
        if (!s_types.TryGetValue(key, out var type))
        {
            type = new TreeType(name, color, texture);
            s_types[key] = type;
            Console.WriteLine($"[factory] created shared TreeType: {name}");
        }
        return type;   // same instance every time for this key
    }

    public static int DistinctTypes => s_types.Count;
}