using DesignPatterns.Decorator;
using DesignPatterns.Observer;
using DesignPatterns.Strategy;

Console.WriteLine("Welcome to the C# Design Patterns!");
Console.WriteLine();

Console.WriteLine("----- Strategy Design Pattern -----");
var strategyPattern = new StrategyPattern();
strategyPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Observer Design Pattern -----");
var observerPattern = new ObserverPattern();
observerPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Decorator Design Pattern -----");
var decoratorPattern = new DecoratorPattern();
decoratorPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Factory Design Pattern -----");
var factoryPattern = new FactoryPattern();
factoryPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Singleton Design Pattern -----");
var singletonPattern = new SingletonPattern();  
singletonPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Command Design Pattern -----");
var commandPattern = new CommandPattern();  
commandPattern.Run();
Console.WriteLine();