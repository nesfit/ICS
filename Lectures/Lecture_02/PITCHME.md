# Object-oriented programming and advanced constructs in C#
## OOP, Exceptions, events, delegates, lambda expressions and generics
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
## Object Oriented Programming (OOP)
* First appearance in **SIMULA 67**
* Abstraction of real word 
* Real object (dog) has some properties (**length, color of coat, ...**) and an ability to do something (**bark, bite**)
* OOP Object interconnects data and behavior together
  * **Behavior** is described by **procedures** and **functions**, both called in OOP as **methods**
  * Data is stored in object's **member variable (field)**
  * **Methods** and **fields** together create objects

+++?code=/Lectures/Lecture02/Assets/sln/Example/Dog.cs&lang=C#&title=OOP Sample
@[3-14]
@[5-6]
@[8-11, 13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Dog.cs)

+++
### Three Principles of OOP
* OOP interconnects **data** and **logic**
  * **Encapsulation**
  * **Inheritance**
  * **Polymorphism**

+++
#### Encapsulation
* Hides implementation details
* Improves modularity
* Definitions:
  * A language mechanism for **restricting direct access** to some of the **object's components**
  * A language construct that **facilitates the bundling of data with the methods** (or other functions) operating on that data

+++
#### Inheritance
* Create objects that are built upon existing objects
* Specify a new implementation to maintain the same behavior
* Reuse code and to independently extend original software via public classes
* An *inherited class* is called a **subclass** of its **parent class** or **superclass** or **base class**

+++?code=/Lectures/Lecture02/Assets/sln/Example/Animal.cs&lang=C#&title=Inheritance Sample
@[3-6]
@[3-4, 6]
@[5]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Animal.cs)

+++?code=/Lectures/Lecture02/Assets/sln/Example/Dog.cs&lang=C#&title=Inheritance Sample
@[3-14]
@[3-4, 14]
@[8-11]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Dog.cs)

+++
##### Inheritance and Subtyping
* In some languages inheritance and subtyping are no different
* Generally in statically-typed class-based OO languages, such as (C++, C#, Java), whereas in others they differ
  * **subtyping** *establishes an is-a relationship*
  * **inheritance**:
    * only *reuses implementation and establishes* a **syntactic relationship**
    * not necessarily a **semantic relationship**, inheritance does not ensure behavioral subtyping
* **Subtyping** is also known as **interface inheritance** whereas inheritance as defined here is known as implementation inheritance or code inheritance
* Still, **inheritance** is a commonly used mechanism for establishing subtype relationships

+++
#### Polymorphism
* Is the provision of a *single interface* to *entities of different types*
* A polymorphic type is one whose operations can also be applied to values of some other type, or types

+++
##### Polymorphism Types
* **Ad hoc polymorphism**:
  * **Function overloading**
  * *Function denotes different and potentially heterogeneous implementations* depending on a limited range of *individually specified types and combinations*
* **Parametric polymorphism**:
  * Code is written *without mention of any specific type* and thus *can be used transparently with any number of new types*
  * This is often known as **generics** in OOP, and *polymorphism* in functional programming
* **Subtyping** (*subtype polymorphism* or *inclusion polymorphism*):
  * Name denotes instances of many different classes related by some common *base* class

---
## Types
* `class` - construction plan for an object
* `enum` - enum data type as known from other languages
* `interface` - mechanism to allow *subtype polymorphism*
* `struct` - value type, alternation to class, do *not allow inheritance*, only *subtyping*

+++
### Identificators
  * `null` - a reference that  *points to nowhere*
  * `this` - a reference to a *current instance* of an object
  * `base` - a reference to a *subtype* of a *supper class*

+++
### Access Modifiers
* Used for limiting access to *implementation details*
* Ensure *encapsulation* and leads to safe code
* If a modifier is omitted, the most restrictive one is used

+++

| Modifier | Visibility |
|-|-|
|`public` | accessed *everywhere* |
|`private` | accessed only in the **same** *class* or *struct* |
|`protected` | accessed only by code in the **same** *class*, or in a *class* **that is derived** from that class |
|`internal` | accessed in the **same assembly**, but not from another assembly |
|`protected internal` | accessed in the assembly in which it is declared, or from within a **derived** *class* in another assembly |
|`private protected` |  accessed **only within its declaring assembly**, by code in the same class or in a type that is derived from that class |

---
## Class
* Most common kind of reference type
* Construction plan for an object
* Encapsulates *data* and *behavior*
  ```C#
  class YourClassName
  {
  }
  ```

+++
### Static / non static
* `static` - **only one** instance for program run
* *non static* - classes are **instanciated** during program run

+++
### Class may contain
| | |
|-|-|
|Preceding the keyword class |Attributes and class modifier |
|Following YourClass Name    |Generic type parameters, a base class, and interfaces|
|Within the braces           |Methods, properties, indexers, events, fields, constructors...|

+++
### Class Components
* **field** – a member variable
* **property** – an accessor for a field
* **method** - named procedure of function
* **event** - notifies object change
* **constructor** - **method** that run initialization code

+++
### Field
* Variable that is a member of a *class* or *struct*
* Initialization
  * Optional
  * Noninitialized has a *default* value (`0, \0, null, false`)
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
* access - `public, internal, private, protected`
* inheritance - `new`
* unsafe code - `unsafe`
* `readonly` - cannot be changed after construction
* threading - `volatile`

+++
### Method
* *Procedures* and *functions* are in OOP called *methods*
* Can access to members of `class` or `struct`
* Can
  * accept parameters - *values*, *reference types*, `ref`
  * return result - in return type (`return`), or `ref` or `out` parameters

+++
#### Method Modifiers
* `static`
* access - `public, internal, private, protected`
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
* Method witch empty return type (`void`):
  ```C#
  void Foo(int x) => Console.WriteLine(x);
  ```

+++
#### Method Overloads
* Return type is not a part of the signature
  ```C#
  void Foo (int x) {...}
  int  Foo (int x) {...} // Compile-time error
  ```
* Method overloads can have different return types
  ```C#
  int    Foo (int x) {...}
  double Foo (double x) {...} // OK
  ```

+++
#### Local Methods
* Defines a method inside another method
* Is visible only to the enclosing method
* Can access the local variables and parameters of the enclosing method
  ```C#
  void WriteCubes()
  {
    Console.WriteLine (Cube (3));
    Console.WriteLine (Cube (4));
    Console.WriteLine (Cube (5));
    int Cube (int value) => value * value * value;
  }
  ```

+++
### Property
* Similar to a *field*, but **it encloses it with access methods**
* It is a safety mechanism that unifies *read* and *write* operations
* Hides *implementation details*

+++
#### Read-only and Calculated Property
* *Read-only* if it specifies only a `get` accessor
* *Write-only* if it specifies only a `set` accessor
  * Rarely used

+++
#### Get and Set Accessibility
* *Get* and *set* accessors can have different access levels
* Typical use:
  * `public` property 
  * `internal` or `private` access modifier on the *setter*
    ```C#
    private decimal foo;
    public decimal Foo
    {
      get { return foo; }
      private set { foo = Math.Round (value, 2); }
    }
    ```

+++
#### Property Modifiers
* `static`
* access - `public, internal, private, protected`
* inheritance - `new, virtual, abstract, override, sealed`
* unsafe code - `unsafe, extern`

+++
#### Property Types
* Autogenerated property:
  ```C#
  public string Name {get; set;}
  ```
* Full property (with the backing field):
  ```C#
  private string _name;
  public string Name {
    get { return _name; }
    set { _name = value; }
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
* Run initialization code on a class or struct
* Defined like a method
  * Method name and return type are reduced to the name of the enclosing typeanu
* Constructors of *base* class are accessible

+++?code=/Lectures/Lecture02/Assets/sln/Example/Panda.cs&lang=C#&title=Constructor Sample
@[3-10]
@[6-7, 9]
@[5, 8]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Panda.cs)

+++
#### Implicit Parameterless Constructor
* `public`, *parameterless*
* Generated by C# compiler automatically 
* If and only **if you do not define any constructors**

+++
#### Constructor Modifiers
* Access - `public, internal, private, protected`
* Unsafe code - `unsafe, extern`

+++
#### Constructor Overloading
* Type can have multiple constructors
* The same rules as method overloading
* Protects against code duplication and increases readability
* Keywords
  * `this` - refers to *this* type instance 
  * `base` - refers to *base* class type instance

+++?code=/Lectures/Lecture02/Assets/sln/Example/UnknownCat.cs&lang=C#&title=Constructor Overloading Sample
@[3-20]
@[5]
@[7-10]
@[11-14]
@[5-14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/UnknownCat.cs)

+++?code=/Lectures/Lecture02/Assets/sln/Example/Cat.cs&lang=C#&title=Constructor Overloading Sample
@[3-15]
@[5]
@[7-9]
@[11-14]
@[7-14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Cat.cs)

+++?code=/Lectures/Lecture02/Assets/sln/Tests/Constructor.cs&lang=C#&title=Constructor Overloading Test
@[9-13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/Constructor.cs)

+++
### Deconstructors
* Opposite to a constructor
* From C# 7
* Deconstruction method must
  * Be called **Deconstruct**
  * Have one or more out parameters

+++?code=/Lectures/Lecture02/Assets/sln/Example/Rectangle.cs&lang=C#&title=Deconstructor Sample
@[3-18]
@[5]
@[7-11]
@[13-17]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Rectangle.cs)

+++
#### Call Deconstructor
```C#
var rect = new Rectangle (3, 4);
(float width, float height) = rect; // Deconstruction
Console.WriteLine (width + " " + height); // 3 4
```

<div class="center">
or
</div>

```C#
float width, height;
rect.Deconstruct (out width, out height);
```

<div class="center">
or
</div>

```C#
rect.Deconstruct (out var width, out var height);
```

<div class="center">
or
</div>

```C#
(var width, var height) = rect;
```

<div class="center">
or simply
</div>

```C#
var (width, height) = rect;
```

+++
### Finalizer
* Runs on instance that is no more referenced before is garbage collected
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
  ~Dog()   {
    // Cleanup code
    ...
  }
}
```


+++
### Abstract Class
* **Can never be instantiated**
* Only its concrete subclasses can be instantiated
* Cannot be sealed it must be possible to inherit from it
* Able to define abstract members:
  * Like virtual members, except they don’t provide a default implementation
  * Implementation must be provided by the subclass unless that subclass is also declared
abstract

+++
### Abstract Class Example
```C#
public abstract class Asset
{
  // Note empty implementation
  public abstract decimal NetValue { get; }
}

public class Stock : Asset
{
  public long SharesOwned;
  public decimal CurrentPrice;
  // Override like a virtual method.
  public override decimal NetValue => CurrentPrice * SharesOwned;
}
```

+++
### Virtual
* Can be overridden by subclasses 
* To provide a specialized implementation
* Mechanism of **late binding**
* Virtual can be:
  * Methods
  * Properties
  * Indexers
  * Events

+++ 
### Type Compatibilty
* Easeup usage of *subtypes*, ergo *virtual methods*
* Compatibility of *types* of `class`, `struct` instances
* Determines to which type reference can be assigned reference of another type

+++
#### Upcast
* Creates a *base* class reference from a *subclass* reference
* Only *members* provided by given *base* class can be accessed through upcasted reference

+++?code=/Lectures/Lecture02/Assets/sln/Tests/UpCast.cs&lang=C#&title=Upcast Example
@[6-15]
@[9-14]
@[11]
@[12]
@[13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/UpCast.cs)

+++
#### Downcast
* Creates a *subclass* reference from a *base* class reference
* It **fails**, if *base* class instance is not compatible with *inherited* one

+++?code=/Lectures/Lecture02/Assets/sln/Tests/DownCast.cs&lang=C#&title=Downcast Example
@[7-23]
@[10-15]
@[12]
@[13]
@[14]
@[18-22]
@[20]
@[21]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/DownCast.cs)

+++
#### Operator `as`
* Downcasts
* Return `null` if fails

+++?code=/Lectures/Lecture02/Assets/sln/Tests/AsOperator.cs&lang=C#&title=AS Operator Example
@[6-14]
@[9-13]
@[11]
@[12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/AsOperator.cs)

+++
#### Operator `is`
* Tests whether a reference conversion would succeed
* Usually before downcast

+++?code=/Lectures/Lecture02/Assets/sln/Tests/IsOperator.cs&lang=C#&title=IS Operator Example
@[6-14]
@[9-13]
@[11]
@[12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/IsOperator.cs)

+++?code=/Lectures/Lecture02/Assets/sln/Tests/PatternMatching.cs&lang=C#&title=IS Pattern Matching Example
@[6-28]
@[9-17]
@[11]
@[12-13,15]
@[14,16]
@[20-27]
@[22]
@[23-24, 26]
@[25]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/PatternMatching.cs)

+++
### Sealed
* Restricts
  * Inderitance of `class`
  * Override of *method*

```C#
class Animal { }
 
sealed class Cat : Animal { }
 
//Compile-time error
public class Kitten : Cat {}
```

+++
### System.Object
* Object (`System.Object`) is a common `base` class of all types
* Each type can be cast to `System.Object`
* `System.Object` methods:
  * ToString()
  * Equals()
  * GetHashCode()
  * GetType()
* To get instance type:
  * during *runtime* - `Object.GetType()`
  * during *compile time* - `typeof(object)`

+++
### Partial
* Allows split across multiple files
* Each participant must have the `partial` declaration
* Typically ised in WPF, Winforms
  * one file is auto-generated
  * one file is human edited

```C#
partial class PaymentForm // In auto-generated file
{
  ...
  partial void ValidatePayment (decimal amount);
}
partial class PaymentForm // In hand-authored file
{
  ...
  partial void ValidatePayment (decimal amount)
  {
    if (amount > 100)
    ...
  }
}
```

---
## Struct
* Similar to a class, with the following key differences:
  * A `struct` is a **value type**, whereas a class is a **reference type**
  * A `struct` does not support inheritance (other than implicitly deriving from `System.ValueType`)
* Can have all the members a class can, except:
  * A parameterless constructor
  * Field initializers
  * A finalizer
  * Virtual or protected members
* Each constructor has to initialize all `struct`'s members
* Cannot initialize members in declaration

```C#
public struct Point
{
  int x, y;
  public Point (int x, int y)
  {
    this.x = x; 
    this.y = y;
  }
}
...
Point p1 = new Point (1, 1); // p1.x and p1.y will be 1
Point p2 = new Point (); // p2.x and p2.y will be 0
```

---
## Enums, Flags 
* `enum` is a *value type*
  * creates an enumeration of named numerical values (int, 0,1...)
  * underlying type can be changed to `long`

* `enum` with the attribute `flags`
  * *single variable* may contain *multiple values*

```C#
private enum HorseColor { Siml = 0, Palomino = 5, Ryzak = 10 }

HorseColor color = HorseColor.Siml;
int colorNumber = (int)HorseColor.Ryzak;

HorseColor.TryParse("Ryzak", out HorseColor color);

[Flags] public enum HorseType { None = 0, Racing = 1, 
Breeding = 2, ForSosages = 4, Dead = 8 }

HorseType type = HorseType.Racing | HorseType.Breeding;
type |= HorseType.ForSosages;
Console.WriteLine(type); //Racing, Breeding, ForSosages
```

---
## Interface
* Declares only *specification*, not *implementation* of its members
* All members are `public`
* `class` or `struct` can implement **multiple** `interface`s
* Implementation is provided by `class` or `struct` that implementates particular `interface`
* `interface` can declare
  * methods
  * properties
  * events
  * indexers

```C#
// Defined in System.Collections
public interface IEnumerator
{
  bool MoveNext();
  object Current { get; }
  void Reset();
}
```

+++
#### `interface` vs `abstract`

* Use *inheritance* for types that share its implementation
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
* `class` is considered to be *type*
  * *Data* are stored in member variables
  * *Operations* are declared in methods
* `interface` 
  * describes `class` members
  * behavior is defined in `class` that implements it
* *Multiple inheritance* is not supported
* *Multiple* `interface` *implementation* is supported

  ```C#
  public interface IBoy {
    string Name {get;}
  }
  
  public class Boy: IBoy {
    public string Name { }
  }
  ```

+++
#### Type Safety and Security
* **Strongly typed language**
  * *type* has to be known in *compile time*
* Support of Intellisense in Visual Studio
* Keyword `dynamic` overcomes type safety mechanisms, and type is resolved in *runtime*
* Benefits:
  * Elimination of type issues in  *compile time*
  * Sandboxing protects object state against outer modifications

---
## Generics
* C# has two mechanism for reusable code across different types
  * *Inheritance* - expresses reusability with a *base type*
  * *Generics* - express reusability with a “template” that contains “placeholder” types
    * Type safe code
    * Reduce casting and boxing

+++
### Generics Types
* declares type parameters—placeholder types to be filled in by the consumer of the generic type
  * i.e. `Stack<T>`, designed to stack instances of type `T`:
    ```C#
    public class Stack<T>
    {
      int position;
      T[] data = new T[100];
      public void Push (T obj) => data[position++] = obj;
      public T Pop() => data[--position];
    }
    ```
    used as
    ```C#
    var stack = new Stack<int>();
    stack.Push (5);
    stack.Push (10);
    int x = stack.Pop(); // x is 10
    int y = stack.Pop(); // y is 5
    ```

+++
### Generics Open/Close Types
* *Opened type* – `Stack<T>`
* *Closed type* – `Stack<int>`
  * During a *runtime* all generics are of *closed type*

```C#
var stack = new Stack<T>(); // Illegal: What is T?
```
inside a class  its legal

```
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
### Why Geneerics
* **Reusable across different types**
  * i.e. we need a stack for multiple types:
    * Generics
    * Separate version of the class for every required element type
      *  (e.i., `IntStack`, `StringStack` etc..)
    * Stack that is generalized by using object:
```C#
public class ObjectStack
{
  int position;
  object[] data = new object[10];
  public void Push (object obj) => data[position++] = obj;
  public object Pop() => data[--position];
}
```
Require boxing and downcasting that could not be checked at compile time
```C#
ObjectStack stack = new ObjectStack();
stack.Push ("s"); // Wrong type, but no error!
int i = (int)stack.Pop(); // Downcast - runtime error
```
`ObjectStack` is functionally equivalent to `Stack<object>`

+++
### Generic Methods
* Several basic algorithms can be implemented using *generic methods*.
* *Signature* of generic method contains generic type parameter.
* *Generic method* may contain multiple *generic parameters*
  ```C#
  static void Swap<T> (ref T a, ref T b) {
    T temp = a;
    a = b;
    b = temp;
  }
  ```

+++
### Generic Constraints
* Parameters can be restricted with:
  * `where T :` base class
  * `where T :` interface 
  * `where T :` class 
  * `where T :` struct 
  * `where T :` new() 
  * `where U : T` 


---
## Covariance and Contravariance in Generics
* [Read more](https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance)
* **Covariance** allows use of more derived (more specific) than originally specified.
  * You can assign an instance of `IEnumerable<Derived>` to a variable of type `IEnumerable<Base>`.  
* **Contravariance** allows a use less derived (less specific) than initially specified. 
  * You can assign an instance of `IEnumerable<Base>` to a variable of type `IEnumerable<Derived>`.

* **Invariance** use only of the same type as initially specified.
  *  Invariant generic type parameter is neither **covariant** nor **contravariant**.

+++?code=/Lectures/Lecture02/Assets/sln/Example/CovarianceContravariance.cs&lang=C#&title=Covariance Contravariance Example
@[11]
@[27-30]
@[33-36]
@[11-24]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/CovarianceContravariance.cs)

+++
## Boxing/Unboxing
* C#'s type system is unified such that a value of any type can be treated as an `object`
* Every type in C# directly or indirectly derives from the `object` class type, and `object` is the ultimate *base class* of all types
* Values of reference types are treated as objects simply by viewing the values as type object
* Values of value types are treated as objects by performing **boxing** and **unboxing** operations

+++?code=/Lectures/Lecture02/Assets/sln/Tests/Boxing.cs&lang=C#&title=Boxing Sample
@[8-15]
@[10]
@[11]
@[12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/Boxing.cs)

---
## Exceptions
* Built-in error handling
* Helps to clean-up code
* `try` block
  * Must be followed by:
    * `catch` block
    * `finally` block
    * or both
* `catch` block
  * Executes when an error occurs in the `try` block
  * Has access to an Exception object that contains information about the error
* `finally` block
  * Executes after execution leaves the try block (or if present, the catch block)
  * Whether or not an error occurred

+++
### `try`, `catch`, `finally` example
```C#
try
{
 ... // exception may get thrown within execution of this block
}
catch (ExceptionA ex)
{
 ... // handle exception of type ExceptionA
}
catch (ExceptionB ex)
{
 ... // handle exception of type ExceptionB
}
finally
{
 ... // cleanup code
}
```

+++
### Exception `thrown`
* If exception is in `try` statement:
  * Execution is passed to the compatible `catch` block
  * If the `catch` block successfully finishes
    * If present, Execution is passed to `finally` block
    * Execution moves to the next statement after the `try` statement
* If exeption isn't in `try statement:
  * Execution jumps back to the caller of the function and test is repeated
* If no function takes responsibility for the exception, an error dialog box is displayed to the user, and the program terminates

+++
### The `catch` block
* Specifies what type of exception to catch
  * This must either be `System.Exception` or a subclass of `System.Exception`
* Can handle multiple exception types with multiple catch clauses
* Only one catch clause executes for a given exception
  * Only one catch clause executes for a given exception
  *  If you want to catch more general exceptions you must put the more specific handlers first

+++
#### Multiple `catch` Clauses Example

```C#
class Test
{
  static void Main (string[] args)
  {
    try
    {
      byte b = byte.Parse (args[0]);
      Console.WriteLine (b);
    }
    catch (IndexOutOfRangeException ex)
    {
      Console.WriteLine ("Please provide at least one argument");
    }
    catch (FormatException ex)
    {
      Console.WriteLine ("That's not a number!");
    }
    catch (OverflowException ex)
    {
      Console.WriteLine ("You've given me more than a byte!");
    }
  }
}
```

+++
#### `catch` Simplify Examples
* Exception can be caught without specifying a variable
  ```C#
  catch (OverflowException) // no variable
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
  catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
  {
    ...
  }
  ```

+++
### The `finally` Block
* Always executes
  * Whether or not an exception is thrown
  * Whether or not the `try` block runs to completion
* Typically used for cleanup code

+++
#### The `finally` Block Example

```C#
static void ReadFile()
{
  StreamReader reader = null; // In System.IO namespace
  try
  {
    reader = File.OpenText ("file.txt");
    if (reader.EndOfStream) return;
    Console.WriteLine (reader.ReadToEnd());
  }
  finally
  {
    if (reader != null) reader.Dispose();
  }
}
```

+++
### Throwing Exceptions Example
```C#
class Test
{
  static void Display (string name)
  {
    if (name == null)
      throw new ArgumentNullException (nameof (name));
    Console.WriteLine (name);
  }

  static void Main()
  {
    try { Display (null); }
    catch (ArgumentNullException ex)
    {
      Console.WriteLine ("Caught the exception");
    }
  }
}
```

+++
### Rethrow Examples
* Rethrow same exception
```C#
try { ... }
catch (Exception ex)
{
  // Log error
  ...
  throw; // Rethrow same exception
}
```
* Rethrow a more specific exception
```C#
try
{
  ... // Parse a DateTime from XML element data
}
catch (FormatException ex)
{
  throw new XmlException ("Invalid DateTime", ex);
}
```

+++
### Key Properties of `System.Exception`

* `StackTrace`
  * A string representing all the methods that are called from the origin of the exception to the catch block
* `Message`
  * A string with a description of the error
* `InnerException`
  * The inner exception (if any) that caused the outer exception
  * InnerException may have another InnerException

+++
### Common Exception Types
* `System.ArgumentException`
  * Thrown when a function is called with a bogus argument
* `System.ArgumentNullException`
  * Subclass of `ArgumentException`
  * Thrown when a function argument is (unexpectedly) null
* `System.ArgumentOutOfRangeException`
  * Subclass of `ArgumentException`
  * When a (usually numeric) argument is out of range (usually too big or too small)
* `System.InvalidOperationException`
  * Thrown when the state of an object is unsuitable for a method to successfully execute
* `System.NotSupportedException`
  * Thrown to indicate that a particular functionality is not supported
* `System.NotImplementedException`
  * Thrown to indicate that a function has not yet been implemented
* `System.ObjectDisposedException`
  * Thrown when the object upon which the function is called has been disposed
* `NullReferenceException`
  * The CLR throws this exception
  * Thrown when you attempt to access a member of an object whose value is null


---
## Delegates
* An object that knows how to call a method
* Defines:
  * method's return type
  * method's parameter types 

```C#
delegate int Transformer (int x);
```

<div class="center">
is compatible with
</div>

```C#
static int Square (int x) => x * x;
```

+++
### Delegates Example
```C#
delegate int Transformer (int x);
class Test
{
  static void Main()
  {
    Transformer transformer = Square; // Create delegate instance
    int result = transformer(3); // Invoke delegate
    Console.WriteLine (result); // 9
  }
  static int Square (int x) => x * x;
}
```

+++
### Delegates Shorthands

<div class="center">
The statement:
</div>

```C#
Transformer transformer = Square;
```

<div class="center">
is shorthand for:
</div>

```C#
Transformer transformer = new Transformer (Square);
```

<div class="center">
The expression:
</div>

```C#
transformer(3)
```

<div class="center">
is shorthand for:
</div>

```C#
transformer.Invoke(3)
```

+++
#### Plug-in Methods with Delegates
```C#
public delegate int Transformer (int x);
class Util
{
  public static void Transform (int[] values, Transformer transformer)
  {
    for (int i = 0; i < values.Length; i++)
    values[i] = transformer (values[i]);
  }
}
class Test
{
  static void Main()
  {
    int[] values = { 1, 2, 3 };
    Util.Transform (values, Square); // Hook in the Square method
    foreach (int i in values)
      Console.Write (i + " "); // 1 4 9
  }
  static int Square (int x) => x * x;
}
```
The `Transform` method is a higher-order function (it’s a function that takes a function as an argument).


+++
#### Multicast Delegates
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
### Multicast Delegates Example
```C#
public delegate void ProgressReporter (int percentComplete);
public class Util
{
  public static void HardWork (ProgressReporter progressReporter)
  {
    for (int i = 0; i < 10; i++)
    {
      progressReporter (i * 10); // Invoke delegate
      System.Threading.Thread.Sleep (100); // Simulate hard work
    }
  }
}
```

+++
### Multicast Delegates Example
```C#
class Test
{
  static void Main()
  {
    ProgressReporter progressReporter = WriteProgressToConsole;
    progressReporter += WriteProgressToFile;
    Util.HardWork (p);
  }
  static void WriteProgressToConsole (int percentComplete)
    => Console.WriteLine (percentComplete);
  static void WriteProgressToFile (int percentComplete)
    => System.IO.File.WriteAllText ("progress.txt",
       percentComplete.ToString());
}
```

+++
#### Instance Method Target Example
```C#
public delegate void ProgressReporter (int percentComplete);
class Test
{
  static void Main()
  {
    Foo foo = new Foo();
    ProgressReporter progressReporter = foo.InstanceProgress;
    progressReporter(99); // 99
    Console.WriteLine (progressReporter.Target == foo); // True
    Console.WriteLine (progressReporter.Method); // Void InstanceProgress(Int32)
  }
}
class Foo
{
  public void InstanceProgress (int percentComplete)
    => Console.WriteLine (percentComplete);
}
```

+++
#### `delegate` vs `interface`
* A problem that can be solved with a delegate can also be solved with an interface
* Delegate design may be a better if:
  * The interface defines only a single method
  * Multicast capability is needed
  * The subscriber needs to implement the interface multiple times

+++
#### Delegate Compatibility
* All are incompatible with one another
```C#
delegate void Delegate1();
delegate void Delegate2();
...
Delegate1 delegate1 = Method1;
Delegate2 delegate2 = delegate1; // Compile-time error
```

+++
#### Delegate Equality
* Delegates are equal if they reference the same methods in the
same order
```C#
delegate void Delegate();
...
Delegate delegate1 = Method1;
Delegate delegate2 = Method1;
Console.WriteLine (delegate1 == delegate2); // True
```

---
## Events
* Construct that exposes the subset of delegate features required for the broadcaster/subscriber model

```C#
public delegate void PriceChangedHandler (decimal oldPrice, decimal newPrice);

public class Broadcaster
{
  // Event declaration
  public event PriceChangedHandler PriceChanged;
}
```

+++
#### Standard Event Pattern
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

  public PriceChangedEventArgs (decimal lastPrice, decimal newPrice)
  {
    LastPrice = lastPrice;
    NewPrice = newPrice;
  }
}
```

+++
##### Standard Event Pattern Delegate
* name must end with `EventHandler`
* two arguments
  * the first a subclass`object` *(broadcaster)*
  * the second a subclass of `EventArgs` *(extra informations)*
* return type `void`
* .NET defines a generic delegate `System.EventHandler<>`
  * can be used when an event doesn’t carry extra information

```C#
public delegate void EventHandler<TEventArgs>
 (object source, TEventArgs e) where TEventArgs : EventArgs;
```

+++
#### Standard Event Pattern Example
```C#
public class Stock
{
  ...
  public event EventHandler<PriceChangedEventArgs> PriceChanged;

  protected virtual void OnPriceChanged (PriceChangedEventArgs e)
  {
    if (PriceChanged != null) PriceChanged (this, e);
  }
}
```

+++
### Event Modifiers
* `virtual`
* `override`
* `abstract`
* `sealed`
* `static`

---
## Lambda Expressions
* From C# 3.0
* Unnamed method written in place of a delegate instance
* Form **(parameters) => expression-or-statement-block**
  ```
  x => x * x;
  ```
* parameter `x`
* expression `x * x`
  ```
  x => { return x * x; };
  ```
* Parameter `x`
* Statement block `{ return x * x; }`

+++
### Labda Expressions Usage Example
  ```C#
  delegate int Transformer (int i);
  ...
  Transformer sqr = x => x * x;
  Console.WriteLine (sqr(3)); // 9
  ```
* `x` corresponds to `i`
* `x * x` corresponds to return type `int`

+++
### Lambda Expressions Two Parameters Example

```C#
Func<string,string,int> totalLength = (s1, s2) => s1.Length + s2.Length;
int total = totalLength ("hello", "world"); // 10;
```

+++ 
### Explicitly Specifying Lambda Parameter Types
* Compiler can usually infer the type contextually
* When it can't, you must specify the type explicitly:
  ```C#
  void Foo<T> (T x) {}
  void Bar<T> (Action<T> a) {}
  ...
  Bar ((int x) => Foo (x));
  ```

+++
### Lambda Expression Capturing Outer Variables
* *Outer variables* referenced by a lambda expression are called *captured variables*
* *Lambda expression* that captures variables is called a *closure*
* *Captured variables* 
  * Are evaluated when the delegate is actually *invoked*
  * Have their lifetimes *extended* to that of the delegate

```C#
int factor = 5;
Func<int, int> multiplier = n => n * factor;
factor = 10;
Console.WriteLine (multiplier (3)); // 30
```

+++
### Extended Lifetime Example
```C#
static Func<int> Natural()
{
 int seed = 0;
 return () => seed++; // Returns a closure
}
static void Main()
{
 Func<int> natural = Natural();
 Console.WriteLine (natural()); // 0
 Console.WriteLine (natural()); // 1
}
```

+++
### Extended Lifetime Example
```C#
static Func<int> Natural()
{
 return() => { int seed = 0; return seed++; };
}
static void Main()
{
 Func<int> natural = Natural();
 Console.WriteLine (natural()); // 0
 Console.WriteLine (natural()); // 0
}
```

+++
### Lambda Expressions vs Local Methods
* Local methods functionality overlaps with that overlaps lambda expressions
* Local methods advantages:
  * Recursive without ugly hacks
  * Avoid the clutter of specifying a delegate type
  * Incur slightly less overhead
* In many cases you *need* a delegate
  * i.e., a method with a delegate-typed parameter:

```C#
public void Foo (Func<int,bool> predicate) { ... }
```

---
## Tuples
* Simple way to store a set of values
* Safely return multiple values from a method without resorting to out parameters 
  ```C#
  static (string,int) GetPerson() => ("Bob", 23);
  static void Main()
  {
    (string,int) person = GetPerson(); // Could use 'var' here if we want
    Console.WriteLine (person.Item1); // Bob
    Console.WriteLine (person.Item2); // 23
  }
  ```

+++
### Named Tuples Example
```C#
static (string Name, int Age) GetPerson() => ("Bob", 23);
static void Main()
{
  var person = GetPerson();
  Console.WriteLine (person.Name); // Bob
  Console.WriteLine (person.Age); // 23
}
```

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Types and Programming Languages](https://www.amazon.com/Types-Programming-Languages-MIT-Press/dp/0262162091)  
[Object-Oriented Analysis and Design with Applications](https://www.amazon.com/Object-Oriented-Analysis-Design-Applications-3rd/dp/020189551X)  
[Database Systems: A Practical Approach to Design, Implementation and Management](https://www.amazon.com/Database-Systems-Practical-Implementation-Management/dp/0321210255)  
[C# in Depth](https://www.amazon.com/C-Depth-3rd-Jon-Skeet/dp/161729134X)  
[Microsoft documentation](https://docs.microsoft.com)