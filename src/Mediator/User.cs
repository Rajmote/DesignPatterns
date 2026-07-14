// COLLEAGUE
public class User(string name, IChatRoom room)
{
    public string Name => name;

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        room.Send(Name, message);                 // go through the mediator
    }

    public void Receive(string from, string message) =>
        Console.WriteLine($"  {Name} got from {from}: {message}");
}