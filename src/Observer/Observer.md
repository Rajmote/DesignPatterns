## 1. Observer Pattern

### What is it?
One object (publisher) notifies multiple objects (subscribers) automatically when something changes.
The publisher does not need to know who the subscribers are.

### Key Participants
- **IObservable<T>** — the publisher (the thing being watched)
- **IObserver<T>** — the subscriber (the thing that listens)

### Built-in .NET Interfaces

```csharp
public interface IObserver<T>
{
    void OnNext(T value);        // new value arrived
    void OnError(Exception e);   // stream failed
    void OnCompleted();          // stream finished
}

public interface IObservable<T>
{
    IDisposable Subscribe(IObserver<T> observer); // returns unsubscribe token
}

# Simple Example
public class PhoneObserver : IObserver<string>
{
    public void OnNext(string news)  => Console.WriteLine($"News: {news}");
    public void OnError(Exception e) => Console.WriteLine($"Error: {e.Message}");
    public void OnCompleted()        => Console.WriteLine("No more news.");
}

var agency = new NewsAgency();
IDisposable sub = agency.Subscribe(new PhoneObserver());
agency.PublishNews("It is raining in Pune!");
sub.Dispose();

# When to Use
One object needs to notify many others automatically
Publisher and subscribers must be loosely coupled
Examples: event systems, notifications, live UI updates