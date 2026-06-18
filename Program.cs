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
