using DesignPatterns.Command.KitchenExample;
using DesignPatterns.Command.LightAndFanExample;

namespace DesignPatterns.Command;

// Client
public class CommandPattern
{
    public void Run()
    {
        LightAndFanClient.Run();
        KitchenClient.Run();
    }
}