// ── CLIENT ────────────────────────────────────────────────────
public class TemplateMethodPattern
{
    public void Run()
    {

        Console.WriteLine("=== Making Tea ===\n");
        HotDrink tea = new Tea();
        tea.Prepare();

        Console.WriteLine("\n=== Making Coffee ===\n");
        HotDrink coffee = new Coffee();
        coffee.Prepare();
    }
}