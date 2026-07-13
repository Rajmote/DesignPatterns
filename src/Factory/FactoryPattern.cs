namespace DesignPatterns.Factory;

public class FactoryPattern
{
    public void Run()
    {
        // Simple Factory
        var simpleFactory = new SimpleFactory();
        simpleFactory.Run();

        // Abstract Factory
        var abstractFactory = new AbstractFactory();
        abstractFactory.Run();

        // Factory Method
        var factoryMethod = new FactoryMethod();
        factoryMethod.Run();

    }
}