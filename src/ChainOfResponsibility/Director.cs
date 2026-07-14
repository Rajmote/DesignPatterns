namespace DesignPatterns.ChainOfResponsibility;

public class Director : Approver
{
    protected override bool CanApprove(decimal amount) => amount <= 10_000;
    protected override void Approve(decimal amount) => Console.WriteLine($"Director approved ${amount}");
}
