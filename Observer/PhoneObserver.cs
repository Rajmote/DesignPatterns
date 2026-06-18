namespace DesignPatterns.Observer;

public class PhoneObserver : IObserver<string>
{
    private string _name;
    public PhoneObserver(string name) => _name = name;

    public void OnNext(string news)      => Console.WriteLine($"[{_name}'s Phone] {news}");
    public void OnError(Exception e)     => Console.WriteLine($"[{_name}'s Phone] Error: {e.Message}");
    public void OnCompleted()            => Console.WriteLine($"[{_name}'s Phone] No more news.");
}