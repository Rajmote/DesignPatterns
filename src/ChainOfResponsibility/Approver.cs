// HANDLER — one link in the chain.
public abstract class Approver
{
    private Approver? _next;

    // Wire up the chain; return the link we just added so calls can chain.
    public Approver SetNext(Approver next)
    {
        _next = next;
        return next;
    }

    public void Handle(decimal amount)
    {
        if (CanApprove(amount))
            Approve(amount);              // handle it and stop
        else if (_next is not null)
            _next.Handle(amount);         // pass it along
        else
            Console.WriteLine($"No one can approve ${amount}");   // fell off the end
    }

    protected abstract bool CanApprove(decimal amount);
    protected abstract void Approve(decimal amount);
}