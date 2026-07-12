using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using DesignPatterns.Enumerator;
using DesignPatterns.Iterator;
using DesignPatterns.Observer;
using DesignPatterns.State;
using DesignPatterns.Strategy;
using DesignPatterns.Singleton;

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

Console.WriteLine("----- Adapter Design Pattern -----");
var adapterPattern = new AdapterPattern();  
adapterPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Facade Design Pattern -----");
var facadePattern = new FacadePattern();
facadePattern.Run();
Console.WriteLine();

Console.WriteLine("----- Adapter with Facade Design Pattern -----");
var adapterFacadeCombination = new AdapterFacadeCombination();
adapterFacadeCombination.Run(); 
Console.WriteLine();

Console.WriteLine("----- Composite Design Pattern -----");
var compositePattern = new CompositePattern();
compositePattern.Run();
Console.WriteLine();

Console.WriteLine("----- Enumerator Design Pattern -----");
var enumeratorPattern = new EnumeratorPattern();
enumeratorPattern.Run();
Console.WriteLine();

Console.WriteLine("----- State Design Pattern -----");
var statePattern = new StatePattern();
statePattern.Run();
Console.WriteLine();

Console.WriteLine("----- Iterator Design Pattern -----");
var iteratorPattern = new IteratorPattern();
iteratorPattern.Run();
Console.WriteLine();

Console.WriteLine("----- TemplateMethod Design Pattern -----");
var templateMethodPattern = new TemplateMethodPattern();
templateMethodPattern.Run();
Console.WriteLine();