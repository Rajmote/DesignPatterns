namespace DesignPatterns.Prototype;

public class PrototypePattern
{
    public void Run()
    {
        var original = new Employee("Alice", new Address("Amsterdam"));

        var shallow = original.ShallowClone();
        shallow.Name = "Bob";                 // fine — string is its own copy
        shallow.Address.City = "Rotterdam";   // ⚠ same Address object as original!
        Console.WriteLine(original.Address.City);   // "Rotterdam"  ← original mutated 😱

        var deep = original.DeepClone();
        deep.Address.City = "Utrecht";
        Console.WriteLine(original.Address.City);   // "Rotterdam"  ← original untouched ✓

    }
}
