namespace DesignPatterns.Compound;

// CONTROLLER — turns a button press into a model update.  (Strategy: swappable behaviour)
public class PlusButton
{
    private readonly Counter _model;
    public PlusButton(Counter model) => _model = model;
    public void Press() => _model.Add(1);
}
