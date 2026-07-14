namespace DesignPatterns.Prototype;

public class PrototypePattern
{
    public void Run()
    {
        var original = new Employee("Alice", new Address("Amsterdam"));

        // SHALLOW clone shares the SAME Address, so editing the copy leaks into the original.
        var shallow = original.ShallowClone();
        shallow.Name = "Bob";                 // fine — string is its own copy
        shallow.Address.City = "Rotterdam";   // ⚠ same Address object as original!
        Console.WriteLine($"After shallow-clone edit -> original.City = {original.Address.City}  (shared, leaked!)");

        // DEEP clone gets its OWN Address, so editing the copy leaves the original alone.
        var deep = original.DeepClone();
        deep.Address.City = "Utrecht";
        Console.WriteLine($"After deep-clone edit    -> original.City = {original.Address.City}  (own copy, safe)");

    }
}
