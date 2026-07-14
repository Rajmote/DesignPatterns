namespace DesignPatterns.Interpreter;

// CLIENT — builds an expression tree (AST) out of expression objects, then evaluates it.
public class InterpreterPattern
{
    public void Run()
    {
        // Build the tree for (5 + 3) - 2
        IExpression expression = new Subtract(
            new Add(new Number(5), new Number(3)),
            new Number(2));

        Console.WriteLine($"(5 + 3) - 2 = {expression.Interpret()}");   // 6
    }
}
