namespace DesignPatterns.Facade;
// ── CLIENT ────────────────────────────────────────────────────
// Only talks to BankFacade — no idea subsystems exist
public class FacadePattern
{
    public void Run()
    {
        var bank = new BankFacade();

        // One simple call — all complexity hidden
        bank.OpenAccount("Raj");
        bank.OpenAccount("Anita");
    }
}