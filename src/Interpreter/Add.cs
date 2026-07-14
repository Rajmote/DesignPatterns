namespace DesignPatterns.Interpreter;

// NON-TERMINALS — combine sub-expressions (composites).
public class Add(IExpression left, IExpression right) : IExpression
{
    public int Interpret() => left.Interpret() + right.Interpret();
}
