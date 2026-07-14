namespace DesignPatterns.Mediator;

// CONCRETE MEDIATOR — the only thing that knows every colleague.
public class ChatRoom : IChatRoom
{
    private readonly List<User> _users = [];

    public void Register(User user) => _users.Add(user);

    public void Send(string from, string message)
    {
        foreach (var user in _users.Where(u => u.Name != from))
            user.Receive(from, message);          // broadcast to everyone else
    }
}
