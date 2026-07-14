namespace DesignPatterns.ChainOfResponsibility;

public class Ceo : Approver
{
    protected override bool CanApprove(decimal amount) => amount <= 100_000;
    protected override void Approve(decimal amount) => Console.WriteLine($"CEO approved ${amount}");
}
