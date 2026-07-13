namespace DesignPatterns.Observer;

public class ObserverPattern
{
    public void Run()
    {
        var agency = new NewsAgency();

        // Create observers from a simple list
        var observers = new List<IObserver<string>>
        {
            new PhoneObserver("Raj"),
            new PhoneObserver("Anita"),
            new EmailObserver("john@ccs.nl")
        };

        // Subscribe all of them
        var subscriptions = new List<IDisposable>();
        foreach (var observer in observers)
            subscriptions.Add(agency.Subscribe(observer));

        // Publish — all 3 get notified
        agency.PublishNews("It is raining in Pune!");

        Console.WriteLine("--- Raj unsubscribes ---");
        subscriptions[0].Dispose();

        // Only Anita and John get this
        agency.PublishNews("Traffic jam on highway!");

        Console.WriteLine("--- Agency closes ---");
        agency.Close();
    }
}
