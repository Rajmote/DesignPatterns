// Compound = Observer + Strategy, wired as mini-MVC.

namespace DesignPatterns.Compound;

public class CompoundPattern
{
    public void Run()
    {
        var model = new Counter();
        var view = new Display(model);      // View observes the Model
        var button = new PlusButton(model);  // Controller drives the Model

        button.Press();   // Count = 1
        button.Press();   // Count = 2
    }
}
