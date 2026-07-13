namespace DesignPatterns.Observer;

public class EmailObserver : IObserver<string>
{
    private string _email;
    public EmailObserver(string email) => _email = email;

    public void OnNext(string news) => Console.WriteLine($"[Email → {_email}] {news}");
    public void OnError(Exception e) => Console.WriteLine($"[Email → {_email}] Error: {e.Message}");
    public void OnCompleted() => Console.WriteLine($"[Email → {_email}] No more news.");
}
