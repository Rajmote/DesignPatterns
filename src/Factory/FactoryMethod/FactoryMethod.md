# Factory Method Pattern

> **Intent:** Define a creation method in a base class but let each subclass decide which concrete product to instantiate.

**Category:** Creational

## Participants
- **Creator** (`Logistics`) — abstract base declaring the factory method `CreateTransport()` and the business logic `PlanDelivery()` that uses it.
- **Concrete Creators** (`RoadLogistics`, `SeaLogistics`, `AirLogistics`) — override `CreateTransport()` to return a specific transport.
- **Product** (`ITransport`) — abstraction with `Deliver()`; the base class only ever touches this type.
- **Concrete Products** (`Truck`, `Ship`, `Plane`) — implementations of `ITransport`.
- **Client / Demo** (`FactoryMethod`) — `Run()` holds a `Logistics` reference, swaps concrete creators, and calls `PlanDelivery()`.

## UML class diagram

> New to UML notation? See [UML-GUIDE](../../UML-GUIDE.md).

```mermaid
classDiagram
    class Logistics {
        <<abstract>>
        +CreateTransport()* ITransport
        +PlanDelivery() void
    }
    class RoadLogistics {
        +CreateTransport() ITransport
    }
    class SeaLogistics {
        +CreateTransport() ITransport
    }
    class AirLogistics {
        +CreateTransport() ITransport
    }
    class ITransport {
        <<interface>>
        +Deliver() void
    }
    class Truck {
        +Deliver() void
    }
    class Ship {
        +Deliver() void
    }
    class Plane {
        +Deliver() void
    }

    Logistics <|-- RoadLogistics
    Logistics <|-- SeaLogistics
    Logistics <|-- AirLogistics
    ITransport <|.. Truck
    ITransport <|.. Ship
    ITransport <|.. Plane
    Logistics ..> ITransport : uses
    RoadLogistics ..> Truck : creates
    SeaLogistics ..> Ship : creates
    AirLogistics ..> Plane : creates
```

## Sequence diagram

```mermaid
sequenceDiagram
    participant Demo as FactoryMethod
    participant Logi as RoadLogistics
    participant Truck

    Demo->>Logi: PlanDelivery()
    Logi->>Logi: CreateTransport()
    Logi-->>Logi: Truck
    Note over Logi: prints "Planning delivery..."
    Logi->>Truck: Deliver()
    Truck-->>Logi: Delivering by road in a Truck.
    Note over Demo,Truck: Same shape for SeaLogistics with Ship and AirLogistics with Plane
```

## Flow diagram

```mermaid
flowchart TD
    Client[FactoryMethod.Run] -->|holds Logistics ref| Logistics[Logistics.PlanDelivery]
    Logistics -->|calls factory method| Create[CreateTransport overridden]
    Road[RoadLogistics] --> Create
    Sea[SeaLogistics] --> Create
    Air[AirLogistics] --> Create
    Create -->|RoadLogistics| Truck[Truck]
    Create -->|SeaLogistics| Ship[Ship]
    Create -->|AirLogistics| Plane[Plane]
    Truck --> ITransport[ITransport]
    Ship --> ITransport
    Plane --> ITransport
    ITransport -->|Deliver| Logistics
```

## How it works (in this project)
1. `FactoryMethod.Run()` assigns `Logistics logistics = new RoadLogistics()` and calls `logistics.PlanDelivery()`.
2. `PlanDelivery()` (defined once in `Logistics`) calls the overridden `CreateTransport()`, which returns a `Truck`, then invokes `Deliver()` → `Delivering by road in a Truck.`
3. The demo reassigns `logistics` to `SeaLogistics` then `AirLogistics`; the same `PlanDelivery()` now produces a `Ship`, then a `Plane`.
4. Adding a new transport means adding a `Concrete Product` plus a `Concrete Creator` — `Logistics` never changes.

## When to use
- You do not know ahead of time which concrete product is needed.
- You want subclasses to decide what gets created while sharing common workflow.
- You want to add new product types without touching existing code.

## Analogy
A logistics firm: the delivery process is fixed, but the road, sea, and air branches each provide their own vehicle.
