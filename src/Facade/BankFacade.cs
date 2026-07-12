namespace DesignPatterns.Facade;

// ── FACADE ────────────────────────────────────────────────────
// Single entry point — hides all complexity from client
// Client only talks to this class
public class BankFacade
{
    // All subsystem classes created and managed inside Facade
    private IdentityService      _identityService      = new();
    private CreditService        _creditService        = new();
    private AccountService       _accountService       = new();
    private CardService          _cardService          = new();
    private OnlineBankingService _onlineBankingService = new();

    // One simple method for client — coordinates all subsystems
    public void OpenAccount(string name)
    {
        Console.WriteLine($"\n[Bank] Opening account for {name}...\n");

        _identityService.Verify(name);        // step 1
        _creditService.Check(name);           // step 2
        _accountService.Create(name);         // step 3
        _cardService.IssueDebitCard(name);    // step 4
        _onlineBankingService.Setup(name);    // step 5

        Console.WriteLine($"\n[Bank] Account successfully opened for {name}!\n");
    }

    // Another simple method — close account
    public void CloseAccount(string name)
    {
        Console.WriteLine($"\n[Bank] Closing account for {name}...\n");

        _cardService.IssueDebitCard(name);    // block card
        _accountService.Create(name);         // close account
        _onlineBankingService.Setup(name);    // revoke access

        Console.WriteLine($"\n[Bank] Account closed for {name}!\n");
    }
}
