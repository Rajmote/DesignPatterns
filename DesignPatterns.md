# Design Patterns 

---

## Creational Patterns
> Deal with **object creation**. Control how and what objects are created.

| Pattern | What it does | When to use |
|---|---|---|
| **Singleton** | Ensures only one instance exists | Logger, config, cache — one shared instance needed |
| **Factory Method** | Subclass decides which object to create | You don't know which object you need until runtime |
| **Abstract Factory** | Creates families of related objects | Need matching sets of objects (UI themes, DB providers) |
| **Builder** | Builds complex objects step by step | Object has many optional parts (query builder, order form) |
| **Prototype** | Creates new object by cloning existing one | Object creation is expensive, need a copy with small changes |

---

## Structural Patterns
> Deal with **object composition**. How objects are assembled and connected.

| Pattern | What it does | When to use |
|---|---|---|
| **Adapter** | Makes incompatible interfaces work together | Integrating third-party or legacy code |
| **Decorator** | Adds behaviour to object at runtime | Add features without changing the class (coffee add-ons, streams) |
| **Facade** | Simplifies a complex subsystem | Hide complexity behind a simple interface |
| **Composite** | Treats individual objects and groups the same way | Tree structures (file system, UI components, org charts) |
| **Proxy** | Controls access to another object | Lazy loading, access control, logging, caching |
| **Bridge** | Separates abstraction from implementation | Both abstraction and implementation should be extensible |
| **Flyweight** | Shares common state between many objects | Large number of similar objects consuming too much memory |

---

## Behavioral Patterns
> Deal with **communication between objects**. How objects interact and share responsibility.

| Pattern | What it does | When to use |
|---|---|---|
| **Observer** | Notifies many objects when one changes | Event systems, live UI updates, notifications |
| **Strategy** | Swaps algorithms at runtime | Multiple ways to do the same thing (sort, payment, discount) |
| **Command** | Wraps a request as an object | Undo/redo, queuing actions, logging operations |
| **Template Method** | Defines skeleton of algorithm, subclasses fill in steps | Same steps every time but some steps vary (data parsers, reports) |
| **Iterator** | Sequentially accesses elements without knowing internals | Traversing collections without exposing structure |
| **State** | Changes object behaviour when its state changes | Object behaves differently depending on its current state (traffic light, order status) |
| **Chain of Responsibility** | Passes request along a chain until one handles it | Multiple handlers (middleware, approval workflows, support tiers) |
| **Mediator** | Centralises communication between objects | Many objects talking to each other (chat room, air traffic control) |
| **Memento** | Captures and restores object state | Undo/redo, snapshots, save game state |
| **Visitor** | Adds operations to objects without changing them | New operations on existing class hierarchy (export, reporting) |
| **Interpreter** | Defines grammar and interprets sentences | SQL parsers, expression evaluators, rule engines |

---

## Quick Decision Guide

### Use a Creational pattern when...
- You need to control **how objects are created**
- Object creation is **complex or expensive**
- You need **one specific instance** or **families of objects**

### Use a Structural pattern when...
- You need to **combine or wrap** existing classes
- You want to **simplify** a complex system
- You need to make **incompatible things work together**

### Use a Behavioral pattern when...
- You need to manage **how objects communicate**
- You want to **encapsulate actions or algorithms**
- You need to **reduce dependencies** between objects

---

## Most Commonly Used in Real Projects

| Pattern | Used for |
|---|---|
| **Singleton** | Logger, configuration, database connection |
| **Factory Method** | Creating objects based on type/condition |
| **Builder** | Complex object construction (requests, queries) |
| **Adapter** | Third-party integrations, legacy code |
| **Decorator** | Adding features dynamically (auth, logging, caching) |
| **Facade** | Simplifying complex APIs or services |
| **Observer** | Events, notifications, real-time updates |
| **Strategy** | Payment methods, sorting, export formats |
| **Command** | Undo/redo, job queues, audit logs |
| **Repository** | Data access abstraction (not GoF but widely used) |