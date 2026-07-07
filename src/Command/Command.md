# Command Pattern — Real Time Example
## Online Food Order System

---

## What is it?
Wraps a request as an object, letting you store, queue, and undo operations.
The sender does not need to know who executes the request or how.

---

## Who Does What?

### ICommand (Contract)
- Contract for all order operations
- Has Execute() — place the order
- Has Undo() — cancel the order

### Kitchen (Receiver)
- Does the actual cooking work
- Prepares and cancels food items
- Has no idea about commands or invoker

### PlaceOrderCommand (Concrete Command)
- Wraps one food order as an object
- Holds reference to Kitchen and food item
- Execute() — tells kitchen to prepare food
- Undo() — tells kitchen to cancel food
- Stores food item name — needed to cancel exactly what was ordered

### Waiter (Invoker)
- Takes orders from customer
- Does not know what food is — only knows ICommand
- Passes commands to kitchen via Execute()
- Stores order history in a Stack for cancellation
- CancelLastOrder() pops last command and calls Undo()

### Program / Client
- Customer placing orders
- Creates kitchen, waiter and commands
- Connects everything together

---

## The Flow
Customer
└── creates PlaceOrderCommand (wraps food item + kitchen)
└── gives command to Waiter
└── Waiter calls Execute()
└── PlaceOrderCommand tells Kitchen.PrepareFood()
└── Kitchen prepares the food

Customer cancels
└── tells Waiter to cancel
└── Waiter pops last command from Stack
└── calls Undo()
└── PlaceOrderCommand tells Kitchen.CancelFood()


---

## The Code

```csharp
// ── COMMAND INTERFACE ─────────────────────────────────────────
public interface ICommand
{
    void Execute();    // place the order
    void Undo();       // cancel the order
}

// ── RECEIVER ──────────────────────────────────────────────────
// Kitchen does the actual work — prepare or cancel food
public class Kitchen
{
    // Prepares the food item
    public void PrepareFood(string item)
        => Console.WriteLine($"[Kitchen] Preparing: {item}");

    // Cancels the food item
    public void CancelFood(string item)
        => Console.WriteLine($"[Kitchen] Cancelled: {item}");
}

// ── CONCRETE COMMAND ──────────────────────────────────────────
// Wraps one food order as a command object
public class PlaceOrderCommand : ICommand
{
    private Kitchen _kitchen;    // receiver — does the real work
    private string _foodItem;    // what was ordered — needed for undo

    public PlaceOrderCommand(Kitchen kitchen, string foodItem)
    {
        _kitchen  = kitchen;
        _foodItem = foodItem;
    }

    // Place the order — tell kitchen to prepare
    public void Execute() => _kitchen.PrepareFood(_foodItem);

    // Cancel the order — tell kitchen to cancel
    public void Undo()    => _kitchen.CancelFood(_foodItem);
}

// ── INVOKER ───────────────────────────────────────────────────
// Waiter — takes orders and passes to kitchen
// Does not know what food is — only knows ICommand
public class Waiter
{
    // Keeps history of all placed orders
    private Stack<ICommand> _orderHistory = new Stack<ICommand>();

    // Place an order — execute and save to history
    public void PlaceOrder(ICommand command)
    {
        Console.WriteLine("[Waiter] Sending order to kitchen...");
        command.Execute();
        _orderHistory.Push(command);    // save for possible cancellation
    }

    // Cancel last order
    public void CancelLastOrder()
    {
        if (_orderHistory.Count == 0)
        {
            Console.WriteLine("[Waiter] No orders to cancel.");
            return;
        }

        var lastOrder = _orderHistory.Pop();   // get last order
        Console.WriteLine("[Waiter] Cancelling last order...");
        lastOrder.Undo();                      // cancel it
    }
}

// ── CLIENT ────────────────────────────────────────────────────
// Customer placing orders at the restaurant
class Program
{
    static void Main()
    {
        // Create receiver
        var kitchen = new Kitchen();

        // Create invoker
        var waiter = new Waiter();

        // Create commands — each order wrapped as object
        var order1 = new PlaceOrderCommand(kitchen, "Burger");
        var order2 = new PlaceOrderCommand(kitchen, "Pizza");
        var order3 = new PlaceOrderCommand(kitchen, "Pasta");

        Console.WriteLine("=== Customer Orders ===\n");
        waiter.PlaceOrder(order1);
        waiter.PlaceOrder(order2);
        waiter.PlaceOrder(order3);

        Console.WriteLine("\n=== Customer Cancels Last Order ===\n");
        waiter.CancelLastOrder();

        Console.WriteLine("\n=== Customer Cancels Again ===\n");
        waiter.CancelLastOrder();

        Console.WriteLine("\n=== Try Cancel When Nothing Left ===\n");
        waiter.CancelLastOrder();
        waiter.CancelLastOrder();
        waiter.CancelLastOrder();
    }
}

=== Customer Orders ===

[Waiter] Sending order to kitchen...
[Kitchen] Preparing: Burger

[Waiter] Sending order to kitchen...
[Kitchen] Preparing: Pizza

[Waiter] Sending order to kitchen...
[Kitchen] Preparing: Pasta

=== Customer Cancels Last Order ===

[Waiter] Cancelling last order...
[Kitchen] Cancelled: Pasta

=== Customer Cancels Again ===

[Waiter] Cancelling last order...
[Kitchen] Cancelled: Pizza

=== Try Cancel When Nothing Left ===

[Waiter] Cancelling last order...
[Kitchen] Cancelled: Burger

[Waiter] No orders to cancel.
[Waiter] No orders to cancel.

# Who Knows What
Kitchen     — knows food only         (PrepareFood, CancelFood)
Command     — knows Kitchen + food    (bridges waiter and kitchen)
Waiter      — knows ICommand only     (no idea what food is)
Customer    — knows everything        (creates and connects all)

# Key Takeaway
Without Command:   Waiter → directly calls Kitchen.PrepareFood()  — tightly coupled
With Command:      Waiter → calls Execute() on ICommand           — loosely coupled
                   Waiter does not know Kitchen exists at all

# When to Use

When to Use
You need undo / cancel functionality
You want to queue or schedule operations
You want to log all operations for audit trail
You want to decouple sender from receiver
Examples: food ordering, banking transactions,
e-commerce cart, text editors, CI/CD pipelines                  