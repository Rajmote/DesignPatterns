// MEDIATOR
public interface IChatRoom
{
    void Register(User user);
    void Send(string from, string message);
}