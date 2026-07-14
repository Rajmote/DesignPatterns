namespace DesignPatterns.Interpreter;

// TERMINAL — a literal (leaf).
public class Number(int value) : IExpression
{
    public int Interpret() => value;
}
