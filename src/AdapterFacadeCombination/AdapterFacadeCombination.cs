using DesignPatterns.AdapterFacadeCombination.Facade;

namespace DesignPatterns.AdapterFacadeCombination;
// ── CLIENT ────────────────────────────────────────────────────
// Only knows TravelFacade — has no idea about APIs or Adapters
public class AdapterFacadeCombination
{
    public void Run()
    {
        var travel = new TravelFacade();
        travel.BookTrip("Raj");
        travel.BookTrip("Anita");
    }
}