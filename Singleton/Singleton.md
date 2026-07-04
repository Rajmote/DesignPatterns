# Singleton Pattern

## What is it?
Ensures a class has **only one instance** throughout the entire application
and provides a **global access point** to that instance.

## Real-World Analogy
A game has one global config. No matter where in the game you access it,
you always get the same settings — not a new copy each time.

---

## Who Does What?

### GameConfig (The Singleton)
- Holds the one and only instance of itself
- Blocks anyone from creating a new instance with `new`
- Provides a single door `Instance` to access the one instance
- Stores and manages all game settings
- Any change made through it is visible to everyone immediately

### AudioManager
- Asks `GameConfig.Instance` for the current sound setting
- Does not create or own the config — just reads from it

### VideoManager
- Asks `GameConfig.Instance` for the current resolution setting
- Does not create or own the config — just reads from it

### GameEngine
- Asks `GameConfig.Instance` for the current difficulty setting
- Does not create or own the config — just reads from it

### Lazy\<T\>
- Responsible for creating the instance only when first needed
- Guarantees thread safety — only one thread can create the instance
- Once created, hands back the same instance every time after

---

## Three Rules

| Rule | Who enforces it | What it prevents |
|---|---|---|
| Private constructor | GameConfig itself | Nobody can do `new GameConfig()` from outside |
| Private static field | GameConfig itself | Instance is hidden inside, not exposed directly |
| Public static property | GameConfig itself | Only one controlled door to get the instance |

---

## What This Proves in the Example

- `GameConfig` is created **only once** — no matter how many times it is accessed
- `AudioManager`, `VideoManager`, `GameEngine` all share the **same object**
- A change made in one place is **immediately visible** everywhere else
- `ReferenceEquals` confirms all references point to the **same object in memory**

---

## When to Use
- Logger — one log writer for the whole app
- Configuration — one config object read at startup
- Cache — one shared in-memory cache
- Database connection pool — one shared pool

## When NOT to Use
- When you need multiple instances in the future
- When it makes unit testing hard
- When it holds mutable global state
- In modern .NET apps — use DI container instead

---

## Modern .NET Reality

| | Manual Singleton | DI Singleton |
|---|---|---|
| Who creates the instance | The class itself | The DI container |
| Who controls lifetime | The class itself | The framework |
| Testability | Hard to mock | Easy to mock |
| Preferred in .NET 10 | No | Yes |



# Lazy<T> in C#

## What is it?
**"Do not create this object until someone actually needs it."**
Delays the creation of an object until the first time it is accessed.

---

## Real Life Analogy

| | Meaning |
|---|---|
| **Without Lazy** | You cook a full meal as soon as you wake up even if nobody is hungry yet |
| **With Lazy** | You cook only when someone says "I am hungry" and keep food warm for everyone after |

---

## How it Works

### Without Lazy — Eager Loading

App starts
└── Object is created immediately
even if nobody uses it the entire run
— wasted memory and time

### With Lazy — Lazy Loading
App starts
└── Object is NOT created yet

First access
└── Object is created NOW

Every access after that
└── Returns the SAME already-created object
never creates again

---
## Who Does What?
### Lazy\<T\> wrapper
- Holds the recipe for creating the object — not the object itself
- Waits until someone actually needs the object
- Creates the object exactly once on first access
- Returns the same object on every access after that
### The recipe `() => new GameConfig()`
- Tells Lazy how to create the object when the time comes
- Runs only once — on first access
- Never runs again after that
### `.Value`
- The trigger that says "I need the object now"
- First call — runs the recipe and creates the object
- Every call after — just returns what was already created
---
## Three Guarantees
| Guarantee | Meaning |
|---|---|
| **Created once** | No matter how many threads call `.Value`, object is made only one time |
| **Created late** | Not created until `.Value` is first accessed |
| **Thread safe** | If two threads hit it at the same time, only one wins — other waits |
---
## Mental Model
Lazy<GameConfig> = a box that contains a recipe

First .Value = opening the box
recipe runs, object is created, stored in box

Every .Value after that = just looks inside the box
recipe never runs again

---
## What Lazy Replaces
Without `Lazy<T>` you would have to write all this yourself:
Check if instance is null
Lock the thread
Check again inside the lock
Create the instance
Release the lock
Return the instance
`Lazy<T>` does all of that in one line.
---
## Thread Safety Modes
| Mode | Meaning | Use when |
|---|---|---|
| `ExecutionAndPublication` | Only one thread runs the factory — safest | Default — use this always |
| `PublicationOnly` | Multiple threads can run factory, first one wins | Rare cases |
| `None` | No thread safety | Single-threaded apps only |
---
## When to Use Lazy\<T\>
- Object creation is **expensive** (DB call, file read, heavy computation)
- Object might **not be needed** at all during a run
- You want **thread-safe** single creation without writing lock code yourself
- Used heavily in **Singleton pattern** to delay instance creation
## When NOT to Use Lazy\<T\>
- Object is **always needed** — just create it directly
- Object is **cheap to create** — no benefit
- You need the object **ready before first use** — use eager loading
---
## Key Takeaway
Lazy<T> = create on first use, reuse forever after
.Value = the trigger that creates or returns the object