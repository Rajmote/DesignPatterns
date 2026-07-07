# Facade Pattern
---
## What is it?
Provides a **simplified entry point** to a complex subsystem.
Hides all the complexity behind one simple class.
---
## Important — What "Interface" Means in the Definition
"Simplified interface" in the definition
does NOT mean a C# interface keyword.

It means a simplified WAY to interact
with the system — a simple entry point.

### Two meanings of the word "interface"
| Meaning | What it means |
|---|---|
| **C# interface keyword** | `public interface IPaymentProcessor` — a contract in code |
| **General meaning** | A way to interact with something — like a TV remote is your interface to the TV |
In the Facade definition — it means the general meaning, not the C# keyword.
---
## Real-World Analogy
When you call a bank customer care:
- You say "I want to open an account"
- The agent handles everything behind the scenes
  - Verifies your identity
  - Checks your credit score
  - Creates your account
  - Issues your debit card
  - Sets up internet banking
You talk to one person — the agent is the Facade.
You have no idea what happens behind the scenes.
---
## The Problem it Solves
Without Facade — client does everything manually:
customer.VerifyIdentity()
customer.CheckCreditScore()
customer.CreateAccount()
customer.IssueDebitCard()
customer.SetupInternetBanking()
— too much complexity exposed to client

With Facade — client calls one method:
bankFacade.OpenAccount()
— all complexity hidden inside

---
## Who Does What?
### Subsystem Classes
- Each does one specific job
- Complex individually
- Do not know about the Facade
- Examples: IdentityService, CreditService, AccountService
### BankFacade
- Single entry point for the client
- Knows all subsystem classes
- Coordinates them in the right order
- Hides all complexity from the client
- Client only talks to this
### Client
- Only talks to BankFacade
- Has no idea subsystem classes exist
- One simple method call to get things done
---
## The Flow
Client
└── calls BankFacade.OpenAccount()
└── Facade coordinates internally:
├── IdentityService.Verify()
├── CreditService.Check()
├── AccountService.Create()
├── CardService.IssueDebitCard()
└── OnlineBankingService.Setup()

---
## The Code
```csharp
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
}
// ── CLIENT ────────────────────────────────────────────────────
// Only talks to BankFacade — no idea subsystems exist
class Program
{
    static void Main()
    {
        var bank = new BankFacade();
        // One simple call — all complexity hidden
        bank.OpenAccount("Raj");
        bank.OpenAccount("Anita");
    }
}

# Output

[Bank] Opening account for Raj...
[IdentityService]      Identity verified for Raj.
[CreditService]        Credit score checked for Raj.
[AccountService]       Account created for Raj.
[CardService]          Debit card issued for Raj.
[OnlineBankingService] Internet banking set up for Raj.
[Bank] Account successfully opened for Raj!

# Who Knows What

Client               →  knows BankFacade only
BankFacade           →  knows all subsystem classes
IdentityService      →  knows its own job only
CreditService        →  knows its own job only
AccountService       →  knows its own job only
CardService          →  knows its own job only
OnlineBankingService →  knows its own job only

# Do You Need a C# Interface on Facade?

// Optional — add only when you need to mock or swap implementations
public interface IBankFacade
{
    void OpenAccount(string name);
    void CloseAccount(string name);
}
public class BankFacade : IBankFacade { ... }

# Add it when:

You want to mock the Facade in unit tests
You want multiple Facade implementations
You want to follow Dependency Inversion (SOLID)

# When to Use
You want to hide complexity of a subsystem
You want a simple entry point to a complex system
You want to reduce dependencies between client and subsystem
Examples: bank operations, hotel booking, order processing, startup systems

# Key Takeaway
Without Facade  →  Client knows and calls all subsystems directly — tightly coupled
With Facade     →  Client calls one method                        — loosely coupled
                   Add or change subsystems — client never changes