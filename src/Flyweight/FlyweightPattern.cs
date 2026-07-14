namespace DesignPatterns.Flyweight;

// CLIENT — plants a huge forest that shares just a handful of TreeType flyweights.
public class FlyweightPattern
{
    public void Run()
    {
        var forest = new List<Tree>();

        // Plant a million trees, alternating two kinds. All "Oak" trees share ONE
        // TreeType; all "Pine" trees share another — only the (x, y) differs per tree.
        for (int i = 0; i < 1_000_000; i++)
        {
            var type = i % 2 == 0
                ? TreeTypeFactory.GetTreeType("Oak", "Green", "oak.png")
                : TreeTypeFactory.GetTreeType("Pine", "DarkGreen", "pine.png");
            forest.Add(new Tree(i, i * 2, type));
        }

        // Draw the first few — the position (x, y) is the per-tree extrinsic state.
        foreach (var tree in forest.Take(3))
            tree.Draw();

        Console.WriteLine(
            $"{forest.Count:N0} trees share only {TreeTypeFactory.DistinctTypes} TreeType object(s) in memory.");
    }
}
