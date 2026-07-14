using DesignPatterns.Adapter;
using DesignPatterns.AdapterFacadeCombination;
using DesignPatterns.Bridge;
using DesignPatterns.Builder;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Command;
using DesignPatterns.Composite;
using DesignPatterns.Compound;
using DesignPatterns.Decorator;
using DesignPatterns.Enumerator;
using DesignPatterns.Facade;
using DesignPatterns.Factory;
using DesignPatterns.Flyweight;
using DesignPatterns.Interpreter;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;
using DesignPatterns.Memento;
using DesignPatterns.Observer;
using DesignPatterns.Prototype;
using DesignPatterns.Proxy;
using DesignPatterns.Singleton;
using DesignPatterns.State;
using DesignPatterns.Strategy;
using DesignPatterns.TemplateMethod;
using DesignPatterns.Visitor;

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

Console.WriteLine("----- Bridge Design Pattern -----");
var bridgePattern = new BridgePattern();
bridgePattern.Run();
Console.WriteLine();

Console.WriteLine("----- Proxy Design Pattern -----");
var proxyPattern = new ProxyPattern();
proxyPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Compound Design Pattern -----");
var compoundPattern = new CompoundPattern();
compoundPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Builder Design Pattern -----");
var builderPattern = new BuilderPattern();
builderPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Prototype Design Pattern -----");
var prototypePattern = new PrototypePattern();
prototypePattern.Run();
Console.WriteLine();

Console.WriteLine("----- Flyweight Design Pattern -----");
var flyweightPattern = new FlyweightPattern();
flyweightPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Chain of Responsibility Design Pattern -----");
var chainOfResponsibilityPattern = new ChainOfResponsibilityPattern();
chainOfResponsibilityPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Interpreter Design Pattern -----");
var interpreterPattern = new InterpreterPattern();
interpreterPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Mediator Design Pattern -----");
var mediatorPattern = new MediatorPattern();
mediatorPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Memento Design Pattern -----");
var mementoPattern = new MementoPattern();
mementoPattern.Run();
Console.WriteLine();

Console.WriteLine("----- Visitor Design Pattern -----");
var visitorPattern = new VisitorPattern();
visitorPattern.Run();
Console.WriteLine();
