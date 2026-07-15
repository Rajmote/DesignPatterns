# Decorator Pattern

> **Intent:** Attach extra responsibilities to an object dynamically by wrapping it in another object that shares the same interface.

**Category:** Structural

## Participants
- **Component** (`IBeverage`) — the shared interface (`GetDescription()`, `Cost()`) that both the base object and every wrapper implement.
- **Concrete Component** (`Espresso`) — the base object being decorated; returns its own description and cost.
- **Decorator** (`CondimentDecorator`) — abstract wrapper that holds an `IBeverage` reference and also implements `IBeverage`, so wrappers can nest.
- **Concrete Decorators** (`Milk`, `Sugar`, `WhippedCream`) — each delegates to the wrapped beverage and adds its own text and cost on top.

## UML class diagram

> New to UML notation? See [UML-GUIDE](../UML-GUIDE.md).

```mermaid
classDiagram
    class IBeverage {
        <<interface>>
        +GetDescription() string
        +Cost() decimal
    }
    class Espresso {
        +GetDescription() string
        +Cost() decimal
    }
    class CondimentDecorator {
        <<abstract>>
        #IBeverage Beverage
        #CondimentDecorator(IBeverage beverage)
        +GetDescription() string
        +Cost() decimal
    }
    class Milk {
        +Milk(IBeverage beverage)
        +GetDescription() string
        +Cost() decimal
    }
    class Sugar {
        +Sugar(IBeverage beverage)
        +GetDescription() string
        +Cost() decimal
    }
    class WhippedCream {
        +WhippedCream(IBeverage beverage)
        +GetDescription() string
        +Cost() decimal
    }
    IBeverage <|.. Espresso : implements
    IBeverage <|.. CondimentDecorator : implements
    CondimentDecorator <|-- Milk
    CondimentDecorator <|-- Sugar
    CondimentDecorator <|-- WhippedCream
    CondimentDecorator --> IBeverage : wraps
```

## Sequence diagram

```mermaid
sequenceDiagram
    participant Client as DecoratorPattern
    participant WC as WhippedCream
    participant Su as Sugar
    participant Mi as Milk
    participant Es as Espresso
    Client->>WC: Cost()
    WC->>Su: Cost()
    Su->>Mi: Cost()
    Mi->>Es: Cost()
    Es-->>Mi: 100
    Mi-->>Su: 120 (adds 20)
    Su-->>WC: 130 (adds 10)
    WC-->>Client: 160 (adds 30)
    Note over Client,Es: Cost calls delegate inward, each decorator adds its bit outward
```

## Flow diagram

```mermaid
flowchart TD
    IBeverage[IBeverage - Component]
    Espresso[Espresso - Concrete Component] -. implements .-> IBeverage
    CondimentDecorator[CondimentDecorator - Abstract Decorator] -. implements .-> IBeverage
    Milk[Milk] --> CondimentDecorator
    Sugar[Sugar] --> CondimentDecorator
    WhippedCream[WhippedCream] --> CondimentDecorator
    CondimentDecorator -->|wraps IBeverage| IBeverage
    WhippedCream -->|wraps| Sugar
    Sugar -->|wraps| Milk
    Milk -->|wraps| Espresso
```

## How it works (in this project)
1. `DecoratorPattern.Run()` creates the base object: `IBeverage coffee = new Espresso();`.
2. It wraps it in layers: `coffee = new Milk(coffee)`, then `new Sugar(coffee)`, then `new WhippedCream(coffee)` — each wrapper stores the previous `IBeverage`.
3. Calling `coffee.GetDescription()` walks the chain: `WhippedCream` asks `Sugar`, which asks `Milk`, which asks `Espresso`, and each appends its own text on the way back.
4. `coffee.Cost()` sums the same way: `Espresso` 100 + `Milk` 20 + `Sugar` 10 + `WhippedCream` 30 = 160.

## When to use
- You need to add responsibilities to individual objects at runtime, not to a whole class.
- Subclassing would explode into every combination (MilkSugarCoffee, MilkWhippedCoffee, ...).
- The added behaviour should stack in any order and be removable.

## Analogy
Dressing a coffee: start with espresso, then add milk, sugar, and whipped cream — each topping wraps the last and adds to the description and price.
