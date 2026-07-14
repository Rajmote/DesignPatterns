namespace DesignPatterns.ChainOfResponsibility;

public class Manager : Approver
{
    protected override bool CanApprove(decimal amount) => amount <= 1_000;
    protected override void Approve(decimal amount) => Console.WriteLine($"Manager approved ${amount}");
}
