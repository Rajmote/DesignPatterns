public class FlyweightPattern
{
    public void Run()
    {
        var forest = new List<Tree>();
        for (int i = 0; i < 1_000_000; i++)
        {
            var oak = TreeTypeFactory.GetTreeType("Oak", "Green", "oak.png");  // shared
            forest.Add(new Tree(i, i * 2, oak));
        }
        Console.WriteLine($"{forest.Count:N0} trees, {TreeTypeFactory.DistinctTypes} TreeType(s) in memory.");
        // [factory] created shared TreeType: Oak
        // 1,000,000 trees, 1 TreeType(s) in memory.

    }
}