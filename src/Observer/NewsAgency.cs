
public class NewsAgency : IObservable<string>
{
    private List<IObserver<string>> _observers = new();

    public IDisposable Subscribe(IObserver<string> observer)
    {
        _observers.Add(observer);
        return new Subscription(_observers, observer);
    }

    public void PublishNews(string news)
    {
        foreach (var observer in _observers)
            observer.OnNext(news);
    }

    public void Close()
    {
        foreach (var observer in _observers)
            observer.OnCompleted();
    }

    // Handles unsubscription
    private class Subscription : IDisposable
    {
        private List<IObserver<string>> _list;
        private IObserver<string> _observer;

        public Subscription(List<IObserver<string>> list, IObserver<string> observer)
        {
            _list = list;
            _observer = observer;
        }

        public void Dispose() => _list.Remove(_observer);
    }
}

