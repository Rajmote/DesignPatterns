namespace DesignPatterns.Facade;

public interface IBankFacade
{
    void OpenAccount(string name);
    void CloseAccount(string name);
}