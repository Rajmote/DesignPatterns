namespace DesignPatterns.Mediator;

public class MediatorPattern
{
    public void Run()
    {
        var room = new ChatRoom();
        var alice = new User("Alice", room);
        var bob = new User("Bob", room);
        var carol = new User("Carol", room);
        room.Register(alice); room.Register(bob); room.Register(carol);

        alice.Send("Hi all!");
        // Alice sends: Hi all!
        //   Bob got from Alice: Hi all!
        //   Carol got from Alice: Hi all!

    }
}
