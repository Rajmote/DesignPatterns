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
        
    }
}