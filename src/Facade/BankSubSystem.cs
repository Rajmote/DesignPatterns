namespace DesignPatterns.Facade;

// ── SUBSYSTEM CLASSES ─────────────────────────────────────────
// Each handles one specific job
// Complex individually — client should not deal with these directly

public class IdentityService
{
    // Verifies customer identity documents
    public void Verify(string name)
        => Console.WriteLine($"[IdentityService] Identity verified for {name}.");
}

public class CreditService
{
    // Checks customer credit score
    public void Check(string name)
        => Console.WriteLine($"[CreditService] Credit score checked for {name}.");
}

public class AccountService
{
    // Creates a new bank account
    public void Create(string name)
        => Console.WriteLine($"[AccountService] Account created for {name}.");
}

public class CardService
{
    // Issues a debit card for the account
    public void IssueDebitCard(string name)
        => Console.WriteLine($"[CardService] Debit card issued for {name}.");
}

public class OnlineBankingService
{
    // Sets up internet banking access
    public void Setup(string name)
        => Console.WriteLine($"[OnlineBankingService] Internet banking set up for {name}.");
}