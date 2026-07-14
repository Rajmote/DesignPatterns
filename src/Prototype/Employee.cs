namespace DesignPatterns.Prototype;

public class Employee
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public Employee(string name, Address address) => (Name, Address) = (name, address);

    // SHALLOW — copies fields; the Address reference is SHARED.
    public Employee ShallowClone() => (Employee)MemberwiseClone();

    // DEEP — also clones the nested Address.
    public Employee DeepClone() => new(Name, new Address(Address.City));
}
