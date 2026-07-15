# Mediator Pattern

> **Intent:** Centralize communication between objects in a mediator so they no longer refer to each other directly.

**In plain words:** Like a group chat room — instead of everyone texting everyone one-to-one, each person posts to the room and the room delivers messages to the rest.

**Category:** Behavioral

## Participants
- **Mediator** (`IChatRoom`) — the interface every colleague talks through: `Register` and `Send`.
- **Concrete Mediator** (`ChatRoom`) — holds the list of users and broadcasts each message to everyone except the sender.
- **Colleague** (`User`) — knows only the room, not other users; `Send` posts through the room, `Receive` handles incoming messages.
- **Client** (`MediatorPattern`) — sets up the room and users, then triggers a send.

## UML class diagram

> New to UML notation? See [UML-GUIDE](../UML-GUIDE.md).

```mermaid
classDiagram
    class IChatRoom {
        <<interface>>
        +Register(User user) void
        +Send(string from, string message) void
    }
    class ChatRoom {
        -List~User~ _users
        +Register(User user) void
        +Send(string from, string message) void
    }
    class User {
        -IChatRoom room
        +string Name
        +User(string name, IChatRoom room)
        +Send(string message) void
        +Receive(string from, string message) void
    }
    class MediatorPattern {
        +Run() void
    }
    IChatRoom <|.. ChatRoom : implements
    ChatRoom o-- User : broadcasts to
    User --> IChatRoom : posts through
    MediatorPattern ..> ChatRoom : creates
    MediatorPattern ..> User : creates
```

## Sequence diagram

```mermaid
sequenceDiagram
    participant Client as MediatorPattern
    participant Alice as User (Alice)
    participant Room as ChatRoom
    participant Bob as User (Bob)
    participant Carol as User (Carol)

    Client->>Alice: Send("Hi all!")
    Note over Alice: prints "Alice sends"
    Alice->>Room: Send("Alice", "Hi all!")
    Note over Room: broadcast to everyone except sender
    Room->>Bob: Receive("Alice", "Hi all!")
    Room->>Carol: Receive("Alice", "Hi all!")
```

## Flow diagram

```mermaid
flowchart LR
    Alice[Alice] -->|Send| ChatRoom[ChatRoom mediator]
    Bob[Bob] -->|Send| ChatRoom
    Carol[Carol] -->|Send| ChatRoom
    ChatRoom -->|Receive| Alice
    ChatRoom -->|Receive| Bob
    ChatRoom -->|Receive| Carol
```

## How it works (in this project)
1. `MediatorPattern.Run()` creates one `ChatRoom` and three `User`s (Alice, Bob, Carol), each constructed with a reference to that room.
2. `room.Register(...)` adds each user to the room's internal `_users` list.
3. `alice.Send("Hi all!")` prints "Alice sends" then calls `room.Send("Alice", "Hi all!")` — the user goes through the mediator, never touching Bob or Carol directly.
4. `ChatRoom.Send` loops over `_users.Where(u => u.Name != from)` and calls `Receive` on each, so Bob and Carol get the message but Alice does not echo to herself.

## When to use
- Many objects interact in complex ways and the wiring has become a tangled mesh.
- You want to reuse colleagues independently, without them hard-referencing each other.
- Interaction rules (who talks to whom, filtering) should live in one place.

## When NOT to
- Only two objects talk to each other — a mediator adds a needless middleman.
- The interaction logic is trivial; a direct reference is clearer.

## Gotchas
- Without a mediator, N users need up to N*(N-1) direct links (a peer-to-peer mesh); the room replaces that with hub-and-spoke, so each user knows only the room.
- The mediator can become a "god object" — as rules grow, `ChatRoom` accumulates all the coordination logic and gets hard to maintain.
- Users must be `Register`ed with the room, or they silently receive nothing.
