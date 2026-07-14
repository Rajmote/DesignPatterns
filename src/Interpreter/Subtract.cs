public class Subtract(IExpression left, IExpression right) : IExpression
{
    public int Interpret() => left.Interpret() - right.Interpret();
}