namespace DesignPatterns.ChainOfResponsibility;

public class ChainOfResponsibilityPattern
{
    public void Run()
    {
        var manager = new Manager();
        manager.SetNext(new Director()).SetNext(new Ceo());   // Manager → Director → CEO

        manager.Handle(500);       // Manager approved $500
        manager.Handle(5_000);     // Director approved $5000
        manager.Handle(50_000);    // CEO approved $50000
        manager.Handle(500_000);   // No one can approve $500000
    }
}
