

public class InterpreterPattern
{
    public void Run()
    {
       // (5 + 3) - 2
IExpression expr = new Subtract(
    new Add(new Number(5), new Number(3)),
    new Number(2));

Console.WriteLine(expr.Interpret());   // 6
    }
}


// Add variables via a Context — pass a lookup into Interpret:
// public interface IExpression { int Interpret(IReadOnlyDictionary<string, int> ctx); }

// public class Variable(string name) : IExpression
// {
//     public int Interpret(IReadOnlyDictionary<string, int> ctx) => ctx[name];
// }
// // now "x + 3" evaluates against { ["x"] = 5 } → 8