@snap[north span-100]

# Object-oriented Programming and Advanced Constructs in C#

@snapend

@snap[midpoint span-100]
## OOP, Exceptions, Events, Delegates, Lambda Expressions and Generics
@snapend

@snap[south-east span-40]

[ Jan Pluskal <ipluskal@fit.vutbr.cz> ]

---
## Object Oriented Programming (OOP)
* First appearance in **SIMULA 67**
* Abstraction of real word
* Real object(dog) has some properties(**length, a color of coat, ...**) and an ability to do something(**bark, bite**)
* OOP Object interconnects data and behavior together
  * **Behavior** is described by **procedures** and **functions**, both called **methods** in OOP
  * Data is stored in object's **member variable(field)**
  * **Methods** and **fields** together create objects

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Dog.cs&lang=C#&title=OOP Sample - Ingnore details for now!
@[10-28]

<!-- [Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Dog.cs) -->

+++
## Three Principles of OOP

@snap[north-east span-10]
![](/Lectures/GitPitch/assets/image/Overview_small.png)
@snapend

* OOP interconnects **data** and **logic**
  * **Encapsulation**
  * **Inheritance**
  * **Polymorphism**

+++
### Encapsulation
* Hides implementation details
* Improves modularity
* Definitions:
  * A language mechanism for **restricting direct access** to some of the **object's components**
  * A language construct that **facilitates the bundling of data with the methods**(or other functions) operating on that data

+++
#### Access Modifiers
* Used for limiting access to *implementation details*
* Ensures *encapsulation* and leads to safe code
* **If a modifier is omitted, the most restrictive one is used**

+++
| Modifier | Visibility |
|-|-|
|`public` | accessible *everywhere* |
|`private` | accessible only in the **same** *class* or *struct* |
|`protected` | accessible only in the **same** *class*, or in a *class* **that is derived** from the same class |
|`internal` | accessible in the **same assembly**, but not from another assemblies |
|`protected internal` | accessible in the **same assembly** in which it is declared, **or** from within a **derived** *class* in another assembly(*internal* **OR** *protected*) |
|`private protected` |  accessible **only within its declaring assembly**, in the **same** *class*, **and** in a *class* **that is derived** from the same *class*(*internal* **AND** *protected*) |


+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Dog.cs&lang=C#&title=Encapsulation Sample
@[12,17-21]
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Dog.cs)

+++
### Inheritance
* Create objects that are built upon existing objects
* Specify a new implementation to maintain the same behavior
* Reuse code and to independently extend original software via public classes
* An *inherited class* is called a **subclass** of its **parent class** or **superclass** or **base class**

+++
#### Identificators
  * `null` - a reference that  *points to nowhere*
  * `this` - a reference to a *current instance* of an object
  * `base` - a reference to a *subtype* of a *super class*

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Animal.cs&lang=C#&title=Inheritance Sample
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Animal.cs)

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Pet.cs&lang=C#&title=Inheritance Sample
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Pet.cs)

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Dog.cs&lang=C#&title=Inheritance Sample
@[10-28]
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Dog.cs)

+++
#### Inheritance and Subtyping
* In some languages inheritance and subtyping are no different
* Generally in statically-typed class-based OO languages, such as(C++, C#, Java), whereas in others they differ
  * **subtyping** *establishes an is-a relationship*
  * **inheritance**:
    * only *reuses implementation and establishes* a **syntactic relationship**
    * not necessarily a **semantic relationship**, inheritance does not ensure behavioral subtyping
* **Subtyping** is also known as **interface inheritance** whereas inheritance, as defined here, is known as implementation inheritance or code inheritance
* Still, **inheritance** is a commonly used mechanism for establishing subtype relationships

+++
### Polymorphism
* Is the provision of a *single interface* to *entities of different types*
* A polymorphic type is one whose operations can also be applied to values of some other type, or types

+++
#### Polymorphism Types
* **Ad hoc polymorphism**:
  * **Function overloading**
  * *Function denotes different and potentially heterogeneous implementations* depending on a limited range of *individually specified types and combinations*
* **Parametric polymorphism**:
  * Code is written *without mention of any specific type* and thus *can be used transparently with any number of new types*
  * This is often known as **generics** in OOP, and *polymorphism* in functional programming
* **Subtyping**(*subtype polymorphism* or *inclusion polymorphism*):
  * Name denotes instances of many different classes related by some common *base* class

---
## Class
* The most common of *reference types*
* Think about it s a *construction plan for an object*
* **Encapsulates** *data* and *behavior*
  ```C#
  class Foo
  {
  }
  ```

+++
### Static/non-static
* `static` classes - **only one** instance for an **AppDomain**
  * *static members* belong to the **class** not the *object*
* **non-static** - classes are **instantiated** during program run
  * *non-static members* belongs to the *object*

+++
### Class may contain
| | |
|-|-|
|*Preceding* **the class keyword** |Attributes and class modifier |
|*Following* **the class Name**    |Generic type parameters, a base class, and interfaces|
|*Within* **the class body**       |Methods, properties, indexers, events, fields, constructors...|

+++
### Class Components
* **fields** – a *member variable*
* **properties** – *methods* that are accessed as if they were fields
* **constants** - *fields* or properties whose values are set at compile time and cannot be changed
* **methods** - named *procedures or functions*
* **events** - *notify* on object state changes
* **operators** - overloaded operators
* **indexers** - allow object to *be indexed as an array*
* **constructors** - **methods** that run initialization code
* **finalizer** - **method** called during object destruction
* **nested types** - *types declared within* a class scope

+++
### Field
* Variable that is a member of a *class* or *struct*
* Initialization is:
  * *Optional*
  * Non-initiated has a *default* value (`0, \0, null, false`)
  * Before a constructor call
    ```C#
    class Octopus
    {
      string name;
      public int Age = 10;
    }
    ```

+++
#### Field Modifiers
* `static`
* access - `public, internal, private, protected, protected internal, private protected`
* inheritance - `new`
* unsafe code - `unsafe`
* `readonly` - cannot be changed after construction
* threading - `volatile`

+++
### Method
* *Procedures* and *functions* are in OOP called *methods*
* Can access members of `class` or `struct`
* Can
  * accept parameters - *values*, *reference types*, `ref`, `in`
  * return result - in return type `return`, or `ref` or `out` parameters

+++
#### Method Modifiers
* `static`
* access - `public, internal, private, protected, protected internal, private protected`
* inheritance - `new, virtual, abstract, override, sealed, partial`
* unsafe code - `unsafe, extern`
* asynchronous - `async`

+++
#### Method Types
* Method contains only one expression
* Classical method:

```C#
int Foo(int x) { return x * 2; }
```

* Expression-bodied method:

```C#
int Foo(int x) => x * 2;
```

* Method with empty return type - `void`:

```C#
void Foo(int x) => Console.WriteLine(x);
```

+++
#### Method Signature
* Methods are declared in a *class* or *struct* by specifying:
  *  the **access level** such as public or private,
  *  **optional modifiers** such as abstract or sealed,
  *  the **return value**,
  *  the **name** of the method,
  *  and any method **parameters**.
* These parts together are the **signature of the method**.

* A **return type** *is not part of the signature* for the purposes of method **overloading**.
* A **return type** *is part of the signature* when determining the compatibility between a **delegate** and the method that it points to.

+++
#### Method Overloads
* **Return type** is not a part of the signature for overloading purpose
  ```C#
  void Foo(int x) {...}
  int  Foo(int x) {...} // Compile-time error
  ```
* Method overloads can have different return types
  ```C#
  int    Foo(int x) {...}
  double Foo(double x) {...} // OK
  ```

+++
#### Local Methods
* Defines a **method** *inside another method*
* Is visible only to the enclosing method
* Can access the local variables and parameters of the enclosing method
  ```C#
  void WriteCubes()
  {
    Console.WriteLine(Cube(3));
    Console.WriteLine(Cube(4));
    Console.WriteLine(Cube(5));

    int Cube(int value) => value * value * value;
  }
  ```

+++
### Property
* Similar to a *field*, but **encloses it with an access method**
* It is a safety mechanism that unifies *read* and *write* operations
* Hides *implementation details*

+++
#### Read-only and Calculated Property
* *Read-only* if it specifies only a `get` accessor
* *Write-only* if it specifies only a `set` accessor

```C#
private decimal _foo;

public decimal Foo1
{
  get { return _foo; }
}
public decimal Foo2
{
  private set { _foo = Math.Round(value, 2); }
}
```

+++
#### Get and Set Accessibility
* *Get* and *set* accessors can have different access levels
* Typical use:
  * `public` property
  * `internal` or `private` access modifier on the *setter*

```C#
private decimal _foo;

public decimal Foo
{
  get { return _foo; }
  private set { _foo = Math.Round(value, 2); }
}
```

+++
#### Property Modifiers
* `static`
* access - `public, internal, private, protected, protected internal, private protected`
* inheritance - `new, virtual, abstract, override, sealed`
* unsafe code - `unsafe, extern`

+++
#### Property Types
* Autogenerated property:

```C#
public string Foo {get; set;}
```

* Full property(with the backing field):

```C#
private string _foo;

public string Foo {
  get { return _foo; }
  set { _foo = value; }
}
```

+++
#### Expression-bodied Property
* With only get accessor:

```C#
public string Name => _name;
```

* With set accessor:

```C#
public string Name {
  get => return _name;
  set => _name = value;
}
```

+++
### Constructor
* Run initialization code on a **class** or **struct**
* Defined like a method
  * Method *name and return type* are reduced to the *name of the enclosing type*
* Constructors of the *base* class are accessible

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Panda.cs&lang=C#&title=Constructor Sample
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Panda.cs)

+++
#### Implicit Parameterless Constructor
* `public`, *parameterless*
* Generated by C# compiler automatically
* If, and only if, **you do not define any other constructor**

+++
#### Constructor Modifiers
* Access - `public, internal, private, protected, protected internal`
* Unsafe code - `unsafe, extern`

+++
#### Constructor Overloading
* Type can have *multiple constructors*
* The same rules as method *overloading*
* Protects against code duplication and increases readability
* Keywords
  * `this` - refers to *this* type instance
  * `base` - refers to *base* class type instance

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/WildCat.cs&lang=C#&title=Constructor Overloading Sample
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/WildCat.cs)

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Cat.cs&lang=C#&title=Constructor Overloading Sample
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Cat.cs)

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/Constructor.cs&lang=C#&title=Constructor Overloading Test
@[8-14]
[Code sample](/Lectures/Lecture_02/Assets/sln/Tests/Constructor.cs)

+++
### Deconstructors
* Opposite of a constructor
* From C# 7
* Deconstruction method must
  * Be called **Deconstruct**
  * Have one or more out parameters

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/Rectangle.cs&lang=C#&title=Deconstructor Sample
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/Rectangle.cs)

+++
#### Call Deconstructor
```C#
var rect = new Rectangle(3, 4);
```

```C#
(float width, float height) = rect; // Deconstruction
Console.WriteLine(width + " " + height); // 3 4
```

or

```C#
float width, height;
rect.Deconstruct(out width, out height);
```

or

```C#
rect.Deconstruct(out var width, out var height);
```

or

```C#
(var width, var height) = rect;
```

or

```C#
var(width, height) = rect;
```

+++
### Finalizer
* Runs on an instance of an object when it is referenced no more before the garbage collection
* `override`s `System.Object`'s method `Finalize()`

```C#
protected override void Finalize() {
  // Cleanup code
  ...
  base.Finalize();
}
```

<div class="center">
or simply
</div>

```C#
class Dog {
  ~Dog() {
    // Cleanup code
  }
}
```


+++
### Abstract Class
* **Can never be instantiated**
* Only its concrete subclasses can be instantiated
* Cannot be `sealed`, it must be inheritable
* Is able to define `abstract` members:
  * Like `virtual` members, except they don’t provide a default implementation
  * Implementation must be provided by the **subclass** unless that **subclass** is also declared `abstract`

+++
### Abstract Class Example
```C#
public abstract class Asset
{
  // Note empty implementation
  public abstract decimal NetValue { get; }
}
```

```C#
public class Stock: Asset
{
  public long SharesOwned { get; set; }
  public decimal CurrentPrice { get; set; }

  /// Overriden, like a virtual method.
  public override decimal NetValue => CurrentPrice * SharesOwned;
}
```

+++
### Virtual
* Implementation can be overridden in subclasses
* To provide a specialized/concrete implementation
* Mechanism of **late binding**
* Virtual can be:
  * **Methods**
  * **Properties**
  * **Indexers**
  * **Events**

+++
### Type Compatibility
* Ease-up usage of *subtypes*, ergo *virtual methods*
* Compatibility of *types* of `class`, `struct` instances
* Determines which type references can be assigned into another type reference

+++
#### Up-cast
* Creates a *base* class reference from a *subclass* reference
* Only *members* provided by given *base* class can be accessed through up-casted reference

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/UpCast.cs&lang=C#&title=Upcast Example
@[10-17]
[Code sample](/Lectures/Lecture_02/Assets/slnTests/UpCast.cs)

+++
#### Down-cast
* Creates a *subclass* reference from a *base* class reference
* It **fails**, if *base* class instance is not compatible with *inherited* one

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/DownCast.cs&lang=C#&title=Downcast Example
@[11-17]
@[20-25]
[Code sample](/Lectures/Lecture_02/Assets/slnTests/DownCast.cs)

+++
#### Operator `as`
* Downcasts
* Returns `null`, if failed

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/AsOperator.cs&lang=C#&title=AS Operator Example
@[9-14]
[Code sample](/Lectures/Lecture_02/Assets/slnTests/AsOperator.cs)

+++
#### Operator `is`
* Tests whether a reference conversion would succeed
* Usually before downcast

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/IsOperator.cs&lang=C#&title=IS Operator Example
@[10-15]
[Code sample](/Lectures/Lecture_02/Assets/slnTests/IsOperator.cs)

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/PatternMatching.cs&lang=C#&title=IS Pattern Matching Example
@[10-18]
@[21-28]
[Code sample](/Lectures/Lecture_02/Assets/slnTests/PatternMatching.cs)

+++
### Sealed
* Restricts
  * Inheritance of `class`
  * Overriding of *method*

```C#
class Animal { }
```

```C#
sealed class Cat: Animal { }
```

```C#
//Compile-time error
public class Kitten : Cat {}
```

+++
### System.Object
* Object(`System.Object`) is a common `base` class of all types
* Each type can be cast to `System.Object`
* `System.Object` methods:
  * `ToString()`
  * `Equals()`
  * `GetHashCode()`
  * `GetType()`
* To get type:
  * during *runtime* - `Object.GetType()`
  * during *compile time* - `typeof(object)`

+++
### Partial class/method
* Allows to split declaration across multiple files
* Each participant must have the `partial` declaration
* Typically used in WPF, Winforms
  * one file is auto-generated
  * one file is human edited

```C#
partial class PaymentForm // In auto-generated file
{
  // ...
  partial void ValidatePayment(decimal amount);

  public void InvokeValidation(){
    ValidatePayment(10);
  }
}
```

```C#
partial class PaymentForm // In hand-authored file
{
  // ...
  partial void ValidatePayment(decimal amount)
  {
    if(amount > 100)
    // ...
  }
}
```

---
## Struct
* Similar to a class, with the following key differences:
  * A `struct` is a **value type**, whereas a class is a **reference type**
  * A `struct` does not support inheritance(other than implicitly deriving from `System.ValueType`)
* Can have all the members as class, except:
  * A parameter-less constructor(is implicit)
  * Field initializers
  * A finalizer
  * Virtual or protected members
* Each constructor has to initialize all `struct`'s members
* Members cannot be initialized in `struct`'s declaration

+++
```C#
public readonly struct Point
{
  int x, y;
  public Point(int x, int y)
  {
    this.x = x;
    this.y = y;
  }
}

Point p1 = new Point(1, 1); // p1.x and p1.y will be 1
Point p2 = new Point(); // p2.x and p2.y will be 0
```

---
## Enums, Flags
* `enum` is a *value type*
  * creates an enumeration of named numerical values(int, 0,1...)
  * underlying type can be changed to `long`, `short`, `byte` 

* `enum` with the attribute `flags`
  * *single variable* may contain *multiple values*

```C#
enum HorseColor { Bay = 0, Palomino = 5, Chestnut = 10 }

HorseColor color = HorseColor.Bay;
int colorNumber  = (int) HorseColor.Chestnut;

HorseColor.TryParse("Chestnut", out HorseColor color);
```

```C#
[Flags] enum HorseType { None = 0, Racing = 1,
Breeding = 2, ForSausages = 4, Dead = 8 }

HorseType type  = HorseType.Racing | HorseType.Breeding;
          type |= HorseType.ForSausages ;
Console.WriteLine(type); //Racing, Breeding, ForSosages
```

---
## Interface
* Declares only *specification*, not *implementation* of its members
* All members are `public`
* `class` or `struct` can implement **multiple** `interface`s
* Implementation is provided by `class` or `struct` that implements particular `interface`
* `interface` can declare
  * **methods**
  * **properties**
  * **events**
  * **indexers**

```C#
public interface IEnumerator
{
  bool MoveNext();
  object Current { get; }
  void Reset();
}
```

+++
#### `interface` vs `abstract`

* Use *inheritance* for types that share implementation
* Use `interface` for types that have independent implementations
* A `class`, or `struct` can implement multiple interfaces

```C#
abstract class Animal { }
abstract class Bird : Animal { }
abstract class Insect : Animal { }

interface IFlying {}
interface ICarnivore {}

// Concrete classes:
class Ostrich : Bird { }
class Eagle : Bird, IFlying, ICarnivore { }
class Bee : Insect, IFlying { }
class Flea : Insect, ICarnivore { }
```

* Because animals might share some implementation of their taxonomy, it is possible to declare `Bird` and `Insect` as `abstract class`.
* But, their food intake and whether they fly or not might differ. It is best to declare these properties as `interfaces`, `IFlying` and `ICarnivore`.

+++
#### `class` vs `interface`
* `class` is considered to be a *type*
  * *Data* are stored in member variables
  * *Operations* are declared in methods
* `interface`
  * describes `class` members
  * behavior is defined in `class` that implements it
* *Multiple inheritance* is not supported
* *Multiple* `interface` *implementation* is supported

```C#
public interface IName {
  string Name {get;}
}
```

```C#
public class Pet: IName {
  public string Name { }
}
```

+++
#### Type Safety and Security
* **Strongly typed language**
  * *type* has to be known at *compile time*
* Support of Intellisense in Visual Studio
* Keyword `dynamic` overcomes type safety mechanisms, and type is resolved at *runtime*
* Benefits:
  * Elimination of type issues at *compile time*
  * Sandboxing protects object state against outer modifications

---
## Generics
* C# has two mechanisms for *reusable code across different types*
  * *Inheritance* - expresses reusability with a *base type*
  * *Generics* - express reusability with a *"template"* that contains "placeholder" types
    * *Type safe* code
    * *Reduce casting and boxing*

+++
### Non-generict *object* Stack
```C#
public class ObjectStack
{
  int position;
  object[] data = new object[100];
  public void Push(object obj) => data[position++] = obj;
  public object Pop() => data[--position];
}
```

```C#
ObjectStack stack = new ObjectStack();
stack.Push("s"); // Wrong type, but no error!
int i =(int)stack.Pop(); // Downcast - runtime error
```

+++
### Generics Types
* Declares type parameter/placeholder types to be filled in by the consumer of the generic type
  * i.e., `Stack<T>`, designed to stack instances of type `T`:

```C#
public class Stack<T>
{
  int position;
  T[] data = new T[100];
  public void Push(T obj) => data[position++] = obj;
  public T Pop() => data[--position];
}
```

usage:

```C#
var stack = new Stack<int>();
stack.Push(5);
stack.Push(10);
Assert.Equal(10,stack.Pop());
Assert.Equal(5,stack.Pop());
```

+++
### Generics Open/Close Types
* *Opened type* – `Stack<T>`
* *Closed type* – `Stack<int>`
  * During *runtime* all generics are of *closed type*

```C#
var stack = new Stack<T>(); // Compile-time error outside generic type or method
```


```C#
public class Stack<T>
{
 ...
 public Stack<T> Clone()
 {
 Stack<T> clone = new Stack<T>(); // Legal
 ...
 }
}
```

+++
### Why Generics
* **Reusable across different types**
  * i.e., we need a *stack* for multiple types, we can use:
    * **Generics**, or
    * Have a separate version, of the same class, for every encapsulated type, or
      * (e.i., `IntStack`, `StringStack` etc..)
    * Have *stack* that is generalized by using object:
      * ValueType requires boxing,
      * down-casting that cannot not be checked at compile time

+++
### Generic Methods
* Several basic algorithms can be implemented using *generic methods*.
* *Signature* of generic method contains generic type parameter.
* *Generic method* may contain multiple *generic parameters*

```C#
static void Swap<T>(ref T a, ref T b) {
  T temp = a;
  a = b;
  b = temp;
}
```

+++
### Generic Constraints
* Parameters can be restricted with:
  * `where T : <base class name>` - T must be or derive from the specified base class.
  * `where T : <interface name>` - T must be or implement the specified interface
  * `where T : class` - T must be a reference type
  * `where T : struct` - T must be a value type, not nullable
  * `where T : new()` - T must have a public parameterless constructor
  * `where T : U` - T must be or derive from the argument supplied for U
  * `where T : unmanaged` - T must not be reference type, and must not contain any reference type members at any level of nesting


---
## Covariance and Contravariance
* [Read more](https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance)

* **Covariance** allows use of more derived(more specific) type than originally specified.
  * You can assign an instance of `IEnumerable<Derived>` to a variable of type `IEnumerable<Base>`.

```C#
IEnumerable<Derived> d = new List<Derived>();
IEnumerable<Base> b = d;
```

* **Contravariance** allows a use less derived(less specific) type than initially specified.
  * You can assign an instance of `Action<Base>` to a variable of type `Action<Derived>`

```C#
Action<Base> b =(target) => { Console.WriteLine(target.GetType().Name); };
Action<Derived> d = b;
```

* **Invariance** use of only the same type as initially specified.
  * Invariant generic type parameter is neither **covariant** nor **contravariant**.
  * You **cannot** assign an instance of `List<Base>` to a variable of type `List<Derived>` or vice versa.

+++?code=/Lectures/Lecture_02/Assets/sln/Examples/CovarianceContravariance.cs&lang=C#&title=Covariance Contravariance Example
@[11]
@[27-30]
@[33-36]
@[11-24]
[Code sample](/Lectures/Lecture_02/Assets/sln/Examples/CovarianceContravariance.cs)

+++
## Boxing/Unboxing
* C#'s type system is unified such that a value of *any type can be treated as an `object`*.
* Every type in C# directly or indirectly derives from the `object` class type, and `object` is the ultimate *base class* of all types
* Values of reference types are treated as objects simply by viewing the values as type object
* Values of value types are treated as objects by performing **boxing** and **unboxing** operations

+++?code=/Lectures/Lecture_02/Assets/sln/Tests/Boxing.cs&lang=C#&title=Boxing Sample
@[8-16]
[Code sample](/Lectures/Lecture_02/Assets/slnTests/Boxing.cs)

---
## Exceptions
* C# has [*structured exception handling*](https://docs.microsoft.com/en-us/windows/desktop/debug/structured-exception-handling)
* Improves code readability
* `try` block
  * Must be followed by:
    * `catch` block
    * `finally` block
    * or both
* `catch` block
  * *Executes when an error occurs* in the `try` block
  * Has access to the *exception object that contains information about the error*
* `finally` block
  * *Executes always*, whether or not an error occurred

+++
### `try`, `catch`, `finally` example
```C#
try
{
 ... // exception may get thrown within execution of this block
}
catch(ExceptionA ex)
{
 ... // handle exception of type ExceptionA
}
catch(ExceptionB ex)
{
 ... // handle exception of type ExceptionB
}
finally
{
 ... // cleanup code - unmanaged resources
}
```

+++
### Exception Handling
* If exception is `throw`n in `try` statement:
  * Execution is passed to the compatible `catch` block
  * If the `catch` block successfully finishes
    * If present, Execution is passed to `finally` block
    * Execution moves to the next statement after the `try` statement
* If exception isn't in `try` statement, or is not caught by any `catch` block in the *callstack*:
  * the process is terminated and error message is displayed to the user

@snap[south-east]
[SOURCE](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/)
@snapped

+++
### The `catch` block
* Specifies what type of exception to catch
  * This must either be `System.Exception` or a subclass of `System.Exception`
* Only one catch clause executes for a given exception
  *  More specific handler needs to be declared before general one

+++
#### Multiple `catch` Clauses Example

```C#
class Test
{
  static void Main(string[] args)
  {
    try
    {
      byte b = byte.Parse(args[0]);
      Console.WriteLine(b);
    }
    catch(IndexOutOfRangeException ex)
    {
      Console.WriteLine("Please provide at least one argument");
    }
    catch(FormatException ex)
    {
      Console.WriteLine("That's not a number!");
    }
    catch(OverflowException ex)
    {
      Console.WriteLine("You've given me more than a byte!");
    }
  }
}
```

+++
#### `catch` Simplify Examples
* Exception can be caught without specifying a variable
  ```C#
  catch(OverflowException) // no variable
  {
  ...
  }
  ```
* Furthermore, you can omit both the variable and the type
  ```C#
  catch { ... }
  ```
* Exception filters
  ```C#
  catch(WebException ex) when(ex.Status == WebExceptionStatus.Timeout)
  {
    ...
  }
  ```

+++
### The `finally` Block
* Executes always
  * Whether or not an exception is thrown
  * Whether or not the `try` block runs to completion
* Typically used to handle unmanaged resource

+++
#### The `finally` Block Example

```C#
static void ReadFile()
{
  StreamReader reader = null; // In System.IO namespace
  try
  {
    reader = File.OpenText("file.txt");
    if(reader.EndOfStream) return;
    Console.WriteLine(reader.ReadToEnd());
  }
  finally
  {
    if(reader != null) reader.Dispose();
  }
}
```

If object implements IDisposable, use `using` clause!

+++
### Throwing Exceptions Example
```C#
class Test
{
  static void Display(string name)
  {
    if(name == null)
      throw new ArgumentNullException(nameof(name));
    Console.WriteLine(name);
  }

  static void Main()
  {
    try { Display(null); }
    catch(ArgumentNullException ex)
    {
      Console.WriteLine("Caught the exception");
    }
  }
}
```

+++
### Rethrow Examples
* Rethrow the same exception

```C#
try { ... }
catch(Exception ex)
{
  // Log error
  ...
  throw; // Rethrow the same exception
}
```

* Rethrow a more specific exception

```C#
try
{
  ... // Parse a DateTime from XML element data
}
catch(FormatException ex)
{
  throw new XmlException("Invalid DateTime", ex);
}
```

+++
### Key Properties of `System.Exception`

* `StackTrace`
  * A string representing all the methods that are called from the origin of the exception to the catch block
* `Message`
  * A string with a description of the error
* `InnerException`
  * The inner exception(if any) that caused the outer exception
  * InnerException may have another InnerException

+++
### Common Exception Types
* `System.ArgumentException`
  * Thrown when a function is called with a bogus argument
* `System.ArgumentNullException`
  * Subclass of `ArgumentException`
  * Thrown when a function argument is(unexpectedly) null
* `System.ArgumentOutOfRangeException`
  * Subclass of `ArgumentException`
  * When a(usually numeric) argument is out of range(usually too big or too small)
* `System.InvalidOperationException`
  * Thrown when the state of an object is unsuitable for a method to successfully execute

+++
* `System.NotSupportedException`
  * Thrown to indicate that particular functionality is not supported
* `System.NotImplementedException`
  * Thrown to indicate that a function has not yet been implemented
* `System.ObjectDisposedException`
  * Thrown when the object, upon which the function is called, has been disposed
* `NullReferenceException`
  * The CLR throws this exception
  * Thrown when you attempt to access a member of an object whose value is null


---
## Delegates
* Is a type that represents references to methods with a particular *parameter list* and *return type*.
* When you instantiate a delegate, you can associate its instance with any method with a *compatible signature and return type*.

```C#
delegate int Transformer(int x);
```

is compatible with

```C#
static int Square(int x) => x * x;
```

+++
### Delegates Example
```C#
delegate int Transformer(int x);
...
class Test
{
  static void Main()
  {
    Transformer transformer = Square; // Create delegate instance
    int result = transformer(3);      // Invoke delegate
    Console.WriteLine(result);       // 9
  }
  static int Square(int x) => x * x;
}
```

+++
### Delegates Shorthand

The statement:

```C#
Transformer transformer = Square;
```

is equivalent:

```C#
Transformer transformer = new Transformer(Square);
```

The expression:

```C#
transformer(3)
```

is equivalent:

```C#
transformer.Invoke(3)
```

+++
#### Plug-in Methods with Delegates
```C#
public delegate int Transformer(int x);

class Util {
  public static void Transform(int[] values, Transformer transformer)
  {
    for(int i = 0; i < values.Length; i++)
    values[i] = transformer(values[i]);
  }
}

class Test {
  static void Main() {
    int[] values = { 1, 2, 3 };
    Util.Transform(values, Square); // Hook in the Square method
    foreach(int i in values)
      Console.Write(i + " "); // 1 4 9
  }

  static int Square(int x) => x * x;
}
```

The `Transform` method is a higher-order function(it’s a function that takes a function as an argument).

+++
### Multicast Delegates
* Delegate instance can reference a list of target methods
* The `+` and `+=` operators combine delegate instances
* The `-` and `-=` operators remove delegate instances
```C#
SomeDelegate d = SomeMethod1;
d += SomeMethod2;
```
* Invoking d will now call both `SomeMethod1` and `SomeMethod2`
* Delegates are invoked in the order they are added
* The caller receives the return value from the last method
  * Preceding methods return values are discarded

+++
#### Multicast Delegates Example - Invocation
```C#
public delegate void ProgressReporter(int percentComplete);

public class Util
{
  public static void HardWork(ProgressReporter progressReporter)
  {
    for(int i = 0; i < 10; i++)
    {
      progressReporter(i * 10); // Invoke delegate
      System.Threading.Thread.Sleep(100); // Simulate hard work
    }
  }
}
```

+++
#### Multicast Delegates Example - Declaration
```C#
class Test
{
  static void Main()
  {
    ProgressReporter progressReporter = WriteProgressToConsole;
    progressReporter += WriteProgressToFile;
    Util.HardWork(p);
  }

  static void WriteProgressToConsole(int percentComplete)
    => Console.WriteLine(percentComplete);

  static void WriteProgressToFile(int percentComplete)
    => System.IO.File.WriteAllText("progress.txt",
       percentComplete.ToString());
}
```

+++
### Instance Method/Target

* `Delegate.Method` - Gets the method represented by the delegate.
* `Delegate.Target` - Gets the class instance on which the current delegate invokes the instance method.

```C#
public delegate void ProgressReporter(int percentComplete);

class Program
{
  static void Main()
  {
    Foo foo = new Foo();
    ProgressReporter progressReporter = foo.InstanceProgress;
    progressReporter(99); // 99
    Console.WriteLine(progressReporter.Target == foo); // True
    Console.WriteLine(progressReporter.Method); // Void InstanceProgress(Int32)
  }
}

class Foo
{
  public void InstanceProgress(int percentComplete)
    => Console.WriteLine(percentComplete);
}
```


+++
#### `delegate` vs `interface`
* A problem that can be solved with a delegate can also be solved with an interface
* **Delegate design may be better** if:
  * The interface would define only a single method
  * Multicast capability is needed
  * The subscriber needs to implement the interface multiple times

+++
#### Delegate Compatibility
* All delegates are incompatible with one another

```C#
delegate void Delegate1();
delegate void Delegate2();
...
Delegate1 delegate1 = Method1;
Delegate2 delegate2 = delegate1; // Compile-time error
```

+++
#### Delegate Equality
* Delegates are equal if they reference the same methods in the same order
```C#
delegate void Delegate();
...
Delegate delegate1 = Method1;
Delegate delegate2 = Method1;
Console.WriteLine(delegate1 == delegate2); // True
```

---
## Events
* Construct that exposes the subset of delegate features required for the broadcaster/subscriber model
* [Read more](https://docs.microsoft.com/en-us/dotnet/csharp/distinguish-delegates-events)
```C#
public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

public class Broadcaster
{
  // Event declaration
  public event PriceChangedHandler PriceChanged;
}
```

+++
### Standard Event Pattern
* Used to provide consistency across Framework and user code
* Standard Event Pattern `EventArgs`
  * `System.EventArgs`
  * Predefined class with no members
  * Base class for conveying information for an event

```C#
public class PriceChangedEventArgs : System.EventArgs
{
  public readonly decimal LastPrice;
  public readonly decimal NewPrice;

  public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
  {
    LastPrice = lastPrice;
    NewPrice = newPrice;
  }
}
```

+++
#### Standard Event Pattern - Delegate
* name must end with `EventHandler`
* two arguments
  * the first a subclass of `object` *(broadcaster)*
  * the second a subclass of `EventArgs` *(extra information)*
* return type `void`
* .NET defines a generic delegate `System.EventHandler<T>`
  * can be used when an event doesn’t carry extra information

```C#
public delegate void EventHandler<TEventArgs>
(object source, TEventArgs e) where TEventArgs : EventArgs;
```

+++
#### Standard Event Pattern - Example
```C#
public class Stock
{
  ...
  public event EventHandler<PriceChangedEventArgs> PriceChanged;

  protected virtual void OnPriceChanged(PriceChangedEventArgs e)
  {
    PriceChanged?.Invoke(this, e);
  }
}
```

+++
### Event Modifiers
* `virtual`
* `override`
* `abstract` - the compiler will not generate the `add` and `remove` event accessor
* `sealed`
* `static`

---
## Lambda Expressions
* From C# 3.0
* *Anonymous function* written in place of a delegate instance
* Form **(parameters) => expression-or-statement-block**
  ```C#
  x => x * x;
  ```
* parameter `x`
* expression `x * x`
  ```C#
  x => { return x * x; };
  ```
* Parameter `x`
* Statement block `{ return x * x; }`

+++
### Lambda Expressions Usage Example
  ```C#
  delegate int Transformer(int i);
  ...
  Transformer sqr = x => x * x;
  Console.WriteLine(sqr(3)); // 9
  ```
* `x` corresponds to `i`
* `x * x` corresponds to return type `int`

+++
### Lambda Expressions Two Parameters Example

```C#
Func<string,string,int> totalLength = (s1, s2) => s1.Length + s2.Length;
int total = totalLength("hello", "world"); // 10;
```

* ```Func<T,TResult> Delegate```

```C#
public delegate TResult Func<in T,out TResult>(T arg);
```

+++
### Explicitly Specifying Lambda Parameter Types
* Compiler can usually infer the type contextually
* When it can't, you must specify the type explicitly:
  ```C#
  void Foo<T>(T x) {}
  void Bar<T>(Action<T> a) {}
  ...
  Bar((int x) => Foo(x));
  ```

+++
### Lambda Expression Capturing Outer Variables
* *Outer variables* referenced by a lambda expression are called *captured variables*
* *Lambda expression* that captures variables is called a *closure*
* *Captured variables*
  * Are evaluated when the delegate is *invoked*
  * Have their lifetime *extended* to that of the delegate

```C#
int factor = 5;
Func<int, int> multiplier = n => n * factor;
factor = 10;
Console.WriteLine(multiplier(3)); // 30
```

+++
### Extended Lifetime Example
```C#
static Func<int> Natural()
{
 int seed = 0;
 return() => seed++; // Returns a closure
}
```

```C#
static void Main()
{
 Func<int> natural = Natural();
 Console.WriteLine(natural()); // 0
 Console.WriteLine(natural()); // 1
}
```

+++
### Extended Lifetime Example
```C#
static Func<int> Natural()
{
 return() => { int seed = 0; return seed++; };
}
```

```C#
static void Main()
{
 Func<int> natural = Natural();
 Console.WriteLine(natural()); // 0
 Console.WriteLine(natural()); // 0
}
```

+++
### Lambda Expressions vs. Local Methods
* Local methods functionality overlaps with lambda expressions
* Local methods advantages:
  * Recursive without ugly hacks
  * Avoid the clutter of specifying a delegate type
  * Incurs slightly less overhead
* In many cases you *need* a delegate
  * i.e., a method with a delegate-typed parameter:

```C#
public void Foo(Func<int,bool> predicate) { ... }
```

---
## Tuples
* Simple way to store a set of values
* Safely return multiple values from a method without resorting to out parameters

```C#
static(string,int) GetPerson() =>("Bob", 23);

static void Main()
{
  (string,int) person = GetPerson(); // Could use 'var' here if we want
  Console.WriteLine(person.Item1);  // Bob
  Console.WriteLine(person.Item2);  // 23
}
```

+++
### Named Tuples Example
```C#
static(string Name, int Age) GetPerson() =>("Bob", 23);

static void Main()
{
  var person = GetPerson();
  Console.WriteLine(person.Name); // Bob
  Console.WriteLine(person.Age);  // 23
}
```

---
## References
[C# 8.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-8-0-Nutshell-Definitive-Reference/dp/1492051136)
[Types and Programming Languages](https://www.amazon.com/Types-Programming-Languages-MIT-Press/dp/0262162091)
[Object-Oriented Analysis and Design with Applications](https://www.amazon.com/Object-Oriented-Analysis-Design-Applications-3rd/dp/020189551X)
[Database Systems: A Practical Approach to Design, Implementation and Management](https://www.amazon.com/Database-Systems-Practical-Implementation-Management/dp/0321210255)
[C# in Depth](https://www.amazon.com/C-Depth-3rd-Jon-Skeet/dp/161729134X)
[Microsoft documentation](https://docs.microsoft.com)

+++

## Credits
* Michal Orlíček - for slides preparation
