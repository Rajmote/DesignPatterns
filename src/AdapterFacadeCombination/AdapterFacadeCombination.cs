// ── CLIENT ────────────────────────────────────────────────────
// Only knows TravelFacade — has no idea about APIs or Adapters
public class AdapterFacadeCombination
{
    public static void Run()
    {
        var travel = new TravelFacade();
        travel.BookTrip("Raj");
        travel.BookTrip("Anita");
    }
}