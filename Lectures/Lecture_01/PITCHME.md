@snap[midpoint span-100]

# Introduction to C#, Visual Studio and .NET

@snapend

@snap[south-east span-40]

[ Jan Pluskal <ipluskal@fit.vutbr.cz> ]

@snapend
---
@snap[midpoint span-100]

## Introduction to Visual Studio

@snapend

---
@snap[north]
![](/Lectures/Lecture_01/Assets/img/VisualStudioLogo.png)
@snapend

* Integrated development environment (IDE)
* Feature-rich program that can be used for many aspects of software development:
  * editor
  * debugger
  * builder
  * completion tools
  * graphical designers
  * etc..
* [Free download](https://visualstudio.microsoft.com/vs/")
* [Installation guide](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2017)

+++
@snap[midpoint span-100]
![](/Lectures/Lecture_01/Assets/img/VisualStudioIde.jpg)
@snapend

+++
## Comparison of Visual Studio versions
|  Supported Features                | Community |  Professional | Enterprise |
| ---------------------------------- | --------- | ------------- | ---------- |
| Supported Usage scenarios          | ⚫⚫⚫◯  | ⚫⚫⚫⚫     | ⚫⚫⚫⚫   |
| Development Platform Support       | ⚫⚫⚫◯  | ⚫⚫⚫⚫     | ⚫⚫⚫⚫   |
| Integrated Development Environment | ⚫⚫⚫◯  | ⚫⚫⚫◯      | ⚫⚫⚫⚫  |
| Advanced Debugging and Diagnostics | ⚫⚫◯◯  | ⚫⚫◯◯      | ⚫⚫⚫⚫  |
| Testing Tools                      | ⚫◯◯◯  | ⚫◯◯◯       | ⚫⚫⚫⚫  |
| Cross-platform Development         | ⚫⚫◯◯  | ⚫⚫◯◯      | ⚫⚫⚫⚫  |
| Collaboration Tools and Features   | ⚫⚫⚫◯  | ⚫⚫⚫◯      | ⚫⚫⚫⚫  |

+++
## Only Enterprise features
* Code Map Debugger Integration
* .NET Memory Dump Analysis
* Test Case Management
* Code Coverage with tests
* IntelliTest
* ⋮

---
## Recommended extensions, services, and tools

* Extensions:
  * Resharper
  * Code metrices
  * Markdown Editor
  * Entity Framework Power tools
  * GitFlow
  * Mnemonic templates
* Tools & Services:
  * LinqPad
  * DotPeek
  * Source Tree
  * VSCode
  * Rider
  * Azure DevOps

@snap[east span-60]
![](/Lectures/Lecture_01/Assets/img/VSExtensions.PNG)
@snapend

+++
### [Resharper](https://www.jetbrains.com/resharper/)

@snap[west span-40]

Extends Visual Studio with code inspections. For most inspections provides quick-fixes to improve code in one way or another. Helps safely organize code and move it around the solution.

For more details see [features](https://www.jetbrains.com/resharper/features/).

@snapend

@snap[east span-50]
![](/Lectures/Lecture_01/Assets/img/reshaper_refactor_this.png)
@snapend

+++
### [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/)
* Before Visual Studio Team Services.
* Cloud-hosted private Git repositories
* Agile planning
* Build management
* Test Plans

@snap[east span-50]
![Azure-DevOps](/Lectures/Lecture_01/Assets/img/Azure-DevOps2.png)
@snapend


+++
### [Code Metrices](https://marketplace.visualstudio.com/items?itemName=Elisha.CodeMetrices)
@snap[west span-50]
Visual Studio extension that helps to monitor the code complexity.
As you type, the method complexity "health" is updated, and the complexity is shown near the method.
@snapend

@snap[east span-50]
![Azure-DevOps](/Lectures/Lecture_01/Assets/img/code_metrices.jpg)
@snapend

+++
### [Mnemonic templates](https://github.com/JetBrains/mnemonics)
@snap[west span-50]

Templates for ReSharper that let you quickly generate code and data structures by typing in names.

@snapend

@snap[east span-50]
![](/Lectures/Lecture_01/Assets/img/resharperLiveTemplates_thumb.gif)
@snapend

+++
### [LinqPad](http://www.linqpad.net/)
@snap[west span-40]

LinqPad is not just for LINQ queries, but any C# expression, statement block or program.
Put an end to those hundreds of Visual Studio Console projects cluttering your source folder and join the revolution of LINQPad scripters and incremental developers.

@snapend

@snap[east span-60]
![](/Lectures/Lecture_01/Assets/img/linqpad-sql.gif)
@snapend

+++
### [DotPeek](https://www.jetbrains.com/decompiler/)
@snap[west span-40]

Tool based on ReSharper's bundled decompiler.
It can reliably decompile any .NET assembly into equivalent C# or IL code.

@snapend

@snap[east span-60]
![](/Lectures/Lecture_01/Assets/img/dotpeek.gif)
@snapend

+++
### [Markdown Editor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)
@snap[west span-40]

A full-featured Markdown editor with live preview and syntax highlighting.
Supports GitHub flavored Markdown.

@snapend

@snap[east span-60]
![](/Lectures/Lecture_01/Assets/img/markdown-editor.gif)
@snapend



+++
### [Entity Framework Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
@snap[west span-40]

Useful design-time utilities for EF 6/ EF Core, accessible through the Visual Studio Solution Explorer context menu when right-clicking on a file containing a derived DbContext class.

@snapend

@snap[east span-60]
![](/Lectures/Lecture_01/Assets/img/ef-powertool.PNG)
@snapend


+++
### [GitFlow](https://marketplace.visualstudio.com/items?itemName=vs-publisher-57624.GitFlowforVisualStudio2017)
@snap[west span-50]

Team Explorer extension integrates GitFlow into your development workflow. It lets you easily create and finish feature, release and hotfix branches right from Team Explorer.  For more details about git recommends [Pro Git book](https://git-scm.com/book/en/v2).

@snapend

@snap[east span-40]
![](/Lectures/Lecture_01/Assets/img/gitflow.png)
@snapend

---
## Why To Choose .NET?
@snap[north-east span-10]
![](/Lectures/Lecture_01/Assets/img/Overview_small.png)
@snapend

* Productivity
* Almost every platform
* Performance
* Security
* Large ecosystem
* Open source

@snap[east span-50]
![](/Lectures/Lecture_01/Assets/img/why-developers-choose-dot-net.png)
@snapend

+++
### Productivity
* To develop *high quality applications faster*
* Modern language constructs
  *  *Generics*
  *  Language Integrated Query (*LINQ*)
  *  *Asynchronous programming*
* Extensive class libraries - NuGet
* Common APIs
* *Multi-language* support

@snap[east span-50]
![](/Lectures/Lecture_01/Assets/img/dotneta.png)
@snapend

+++
### Almost every platform
* iOS
* Android
* Windows
* Windows server
* Linux
* Micro-services on cloud

@snap[east span-50]
![](/Lectures/Lecture_01/Assets/img/netcore3.jpg)
@snapend

+++
### Performance
* Applications provide better response times and require less computing power.
* Comparison of web application frameworks with tasks like
  * JSON serialization,
  * database access,
  * and server side template rendering.

@snap[south-east span-50]
![](/Lectures/Lecture_01/Assets/img/Performance.png)
[Source](https://www.techempower.com/benchmarks/#section=data-r16&hw=ph&test=plaintext)
@snapend

+++
### Security
* Immediate **security** benefits via its *managed runtime*
* Prevents *critical issues* like **buffer overflow**
* Patches are released with runtime

+++
### Large ecosystem
* Libraries from the [NuGet package manager](https://www.nuget.org/)
* Visual studio [marketplace](https://marketplace.visualstudio.com/)
* [Extensive partners network](https://vspartner.com/Directory)
* Community support, MVPs, ...

+++
### Open source
* [**.NET Foundation**](https://dotnetfoundation.org/)
* [.NET Core](https://github.com/dotnet/core)
* [.NET Runtime/CoreFX](https://github.com/dotnet/runtime)
* [ASP.NET Core](https://github.com/dotnet/aspnetcore)
* [.NET Standard](https://github.com/dotnet/standard)
* [EF Core](https://github.com/dotnet/efcore)
* [WPF](https://github.com/dotnet/wpf)
* [Reference Source - .NET Framework (readonly)](https://github.com/microsoft/referencesource)
* Independent, Innovative, Commercially-friendly
* Google, JetBrains, Red Hat, Samsung, Unity...

---
# .NET Platform
@snap[north-east span-10]
![](/Lectures/Lecture_01/Assets/img/Overview_small.png)
@snapend

* Language interoperability
* Architecture
* Common Language Runtime
* Benefits
* Garbage collector
* In The Nutshell
* The .NET family of frameworks

@snap[south-east]
[Source](https://blogs.msdn.microsoft.com/cesardelatorre/2016/06/27/net-core-1-0-net-framework-xamarin-the-whatand-when-to-use-it/)
@snapend

@snap[east span-70]
![](/Lectures/Lecture_01/Assets/img/Overview.png)
@snapend

+++
## Language interoperability
@snap[south-east span-70]
![](/Lectures/Lecture_01/Assets/img/Common_Language_Infrastructure.png)
@snapend


+++
## Architecture
@snap[midpoint span-100]
![](/Lectures/Lecture_01/Assets/img/dot_net_architecture.png)
@snapend

+++
## CLR - Common Language Runtime
* The virtual machine component of .NET
* Manages the execution
* Just-in-time compilation
* Similar to Java Virtual Machine

@snap[east span-50]
![](/Lectures/Lecture_01/Assets/img/dot_net_clr.png)
@snapend

+++
## CLR - Benefits
* Performance improvements - *JIT*
* Easy use of *components developed in other languages*
* Extensible *types defined in BCL*
* *Inheritance, interfaces, and overloading* for OOP
* [Free threading](https://stackoverflow.com/questions/3892259/difference-between-free-threaded-and-thread-safe) (MTA Apartment)
* Structured *exception handling*
* Custom *attributes*
* **Garbage collection**
* *Delegates* instead of function pointers

+++
### Garbage collector
* **Automated memory management** without need of programmer intervention
* Uses reachability from GC roots to identify *alive* objects
* *Three generations*

![](/Lectures/Lecture_01/Assets/img/gc_generations.png)


+++
## C# - In The Nutshell
@snap[midpoint span-90]
![](/Lectures/Lecture_01/Assets/img/Csh_in_nutshell_framework.png)
@snapend

+++
## Standard Libraries
|  Library                            | Namespaces                                                                                                                |
|-------------------------------------| ------------------------------------------------------------------------------------------------------------------------- |
| **Base Class Library**              | *System, System.Collections, System.Collections.Generic, System.Diagnostics, System.IO, System.Text, System.Threading...* |
| **Runtime Infrastructure Library**  | *System, System.Reflection, System.Runtime.CompilerServices, System.Runtime.InteropServices...*                           |
| **Network Library**                 | *System, System.Net, System.Net.Sockets...*                                                                               |
| **Reflection Library**              | *System.Globalization, System.Reflection...*                                                                              |
| **XML Library**                     | *System.Xml*                                                                                                              |
| ⋮                                   | ⋮                                                                                                                          |

+++
## The .NET family of frameworks
@snap[midpoint span-80]
![](/Lectures/Lecture_01/Assets/img/dot_net_libraries.png)
@snapend

---
# C# 101
@snap[north-east span-10]
![](/Lectures/Lecture_01/Assets/img/Overview_small.png)
@snapend

* Identifiers
* Keywords
* Literals
* Delimiters
* Operators
* Comments
* Datatypes
* Value Types

@snap[east span-40]
![](/Lectures/Lecture_01/Assets/img/keep-calm-and-focus-on-the-basics.png)
@snapend

+++
## C# is
* **multi-paradigm**;
* **strong typed**;
* **object oriented** (class-based);
* imperative, declarative;
* functional, generic;
* based on c++;
* programming language.

@snap[east span-40]
![](/Lectures/Lecture_01/Assets/img/csh.png)
@snapend

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/HelloWorld.cs&lang=C#&title=Hello World Sample
@[1]
@[3-4, 15]
@[5-6, 14]
@[7-8, 13]
@[9]
@[11]
@[12]
@[1-15]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/HelloWorld.cs)

+++
## Identifiers
* Name given to entities such as *variables*, *methods*, *classes*, etc.
* Tokens which uniquely identify elements
* `value` is a identifier:
  ```C#
  int value;
  ```
* **Reserved keywords** can not be used unless prefix `@` is added
  ```C#
  int @class;
  ```
+++
## Keywords
* **Reserved** words that have *special meaning*
* Meaning can not be changed
* **Can not be directly** used as *identifies*
* `long` is a keyword:
  ```C#
  long count;
  ```
* E.g. ```int, bool, if, for, class, false, public, break```
* [List of all Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

+++
## Contextual Keywords
* **Specific meaning** in a limited program *context*
* **Can be used** as *identifiers outside the context*
* E.g. ```var, await, async, where, set```
* [List of all Contextual Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

+++
## Literals
* Data inserted in a code
```C#
var hitchhikerConstant = 42;
var helloWorld = "Hello World";
var pi = 3.14159;
```

+++
## Delimiters
* Characters used to structure the code
* Curly braces `{`, `}`
  * Creates **code blocks**
  * Used to **impart a scope**
* Semicolon `;`
  * **Delimits statements**
  * Statement *can be written on multiple lines*.

```C#
Console.WriteLine
    (1 + 2 + 3 + 4 + 5);
```

+++
## Operators
  * Used to **combine multiple expressions**
  * E.g., `. () * + -`

```C#
var sum = 1 + 5 * (6 / 2);
```

+++
## Comments
* Line
  ```C#
  // line comment
  ```
* Block -  **Do not use block comments!!!**
  ```C#
  /* Comment can be split
  into multiple lines */
  ```
* Documentation
  ```C#
  /// <summary>
  /// Documents class, method...
  /// </summary>
  ```

---
## Datatypes
@snap[north-east span-10]
![](/Lectures/Lecture_01/Assets/img/Overview_small.png)
@snapend

* Instruct the compiler or interpreter how the programmer intends to use the data
* **Value type**
  * Variable directly **contains data**
  * **Have to be** assigned before accessing
  * Two variables, each have their copy of the data; *an operation on one variable* **DOES NOT** *affect the other*.
* **Reference types** (objects)
  * Variable **stores reference** to the data
  * **DO NOT have to be** assigned before accessing
  * IF two variables reference the same object; *operation on one variable* **DOES** *affect the object referenced by the other variable*.
* [Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables)

+++
## Value Types
@snap[north-east span-10]
![](/Lectures/Lecture_01/Assets/img/Overview_small.png)
@snapend
* **Simple Types**
  * Signed integral: `sbyte, short, int, long`
  * Unsigned integral: `byte, ushort, uint, ulong`
  * Unicode characters: `char`
  * IEEE floating point: `float, double`
  * High-precision decimal: `decimal`
  * Boolean: `bool`
* **Enum types**
  * User-defined types of the form `enum E {...}`
* **Struct types**
  * User-defined types of the form `struct S {...}`
* **Nullable value types** - become reference types
  * Extensions of all other value types with a `null` value
  * [Boxing/Unboxing](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types#boxing-and-unboxing)

+++
### Signed Integral
| Type   |    Size | Range                                                              |
| ------ | ------- | ------------------------------------------------------------------ |
| `sbyte`|  8 bits | range from -128 - 127                                              |
| `short`| 16 bits | range from -32,768 - 32,767                                        |
| `int`  | 32 bits | range from -2,147,483,648 - 2,147,483,647                          |
| `long` | 64 bits | range from –9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |

+++
### Unsigned integral
|  Type   |    Size | Range                                      |
| ------- | ------- | ------------------------------------------ |
| `byte`  |  8 bits | range from 0 - 255                         |
| `ushort`| 16 bits | range from 0 - 65,535                      |
| `uint`  | 32 bits | range from 0 - 4,294,967,295               |
| `ulong` | 64 bits | range from 0 - 18,446,744,073,709,551,615  |

+++
### Floating point
|   Type   |    Size | Range                                                               |
| -------- | ------- | ------------------------------------------------------------------- |
| `float`  | 32 bits | range from $$1.5 × 10^{−45} - 3.4 × 10^{38}$$  7-digit precision    |
| `double` | 64 bits | range from $$5.0 × 10^{−324} - 1.7 × 10^{308}$$  15-digit precision |

+++
### Decimal
|    Type   |    Size  | Range                                                                                         |
| --------- | -------- | --------------------------------------------------------------------------------------------- |
| `decimal` | 128 bits | range is at least $$–7.9 × 10^{−28} - 7.9 × 10^{28}$$ with at least 28-digit precision range |


+++
### Literals notation
* Classical
  * E.g., `127`, `42`, etc...
* Hexadecimal
  * E.g., `0x7F`, `0x2A`, etc...
* Binary
  * E.g., '0B110010', '0b0010_0110_0000_0011', etc...
* Decimal
  * `'.'` character as a delimiter
  * `'e'` character as an exponent

+++
### Numerical data types specification
Using specific character as a suffix

```C#
 Console.WriteLine(1f.GetType());  // Float   (float)
 Console.WriteLine(1d.GetType());  // Double  (double)
 Console.WriteLine(1m.GetType());  // decimal (decimal)
 Console.WriteLine(1u.GetType());  // UInt32  (uint)
 Console.WriteLine(1L.GetType());  // Int64   (long)
 Console.WriteLine(1ul.GetType()); // UInt64  (ulong)
```

+++
### Numerical data types casting
* Transformation of **integral type** to **integral type**:
  * *implicit* when *target type* can accommodate the whole range of *source type*
  * *explicit* otherwise
* Transformation of **decimal type** to **decimal type**:
  * `float` can be *implicitly* casted to `double`
  * `double` has to be casted *explicitly* to `float`
* Transformation of **integral type** to **decimal type**:
  * Casting is *implicit*
* Transformation of **decimal type** to **integral type**:
  * Casting has to be *explicit*
    * Lost precision
    * Truncation can occur

---
## Arithmetic operations
* `+` addition
* `-` subtraction
* `*` multiplication
* `/` division
* `++` incrementation
* `--` decrementation

+++
### Byte, sbyte, short, ushort types
* 8 and 16 bits types do not have arithmetical operations
  * E.g., `byte, sbyte, short, ushort`
  * Compiler does implicitly cast to a large type `int, uint`
```C#
short x = 1, y = 1;
short z = x + y;    // Compile-time error
```
  * Solution is to do an explicit cast
```C#
short x = 1, y = 1;
short z = (short)(x + y); // OK
```

+++
### Numerical Overflow
* Overflow of integral types
```C#
int a = int.MinValue;
a--;
Console.WriteLine(a == int.MaxValue); // True
```
* Usage of `checked` keyword or compiler option **/checked+**
```C#
int a = int.MinValue;
var i = checked(a--); // throw OverflowException
Console.WriteLine(i == int.MaxValue);
```

+++
### Truncation and precision loss
* `float` and `double` are stored in *binary form*
  * which means only multiples of 2 are stored precisely
```C#
float f1 = 0.09f * 100f;
float f2 = 0.09f * 99.999999f;
Assert.False(f1>f2);
```
* `decimal` is stored in decimal form, but it still has a limited precision
```C#
decimal m = 1M  /  6M;                          // 0.1666666666666666666666666667M
double  d = 1.0 / 6.0;                          // 0.16666666666666666
decimal notQuiteWholeM = m + m + m + m + m + m; // 1.0000000000000000000000000002M
double  notQuiteWholeD = d + d + d + d + d + d; // 0.99999999999999989
Console.WriteLine(notQuiteWholeM == 1M);        // False
Console.WriteLine(notQuiteWholeD < 1.0);        // True
```

+++
## Bitwise operations
| Operator |   Meaning   |      Example     |   Result    |
| -------- | ----------- | ---------------- | ----------- |
|    `~`   |     Not     |         `~0xfU`  | 0xfffffffOU |
|    `&`   |     And     |   `0xf0 & 0x33`  | 0x30        |
|  <code>&#124;</code> |      Or     |<code>0xf0 &#x7c; 0x33</code> | 0xf3        |
|    `^`   |     Xor     | `0xff00 ^ 0x00ff`| 0xffff      |
|   `<<`   |  Left shift |  `0x20 << 2`     | 0x80        |
|   `>>`   | Right shift |  `0x20 >> 1`     | 0x10        |

+++
## Character type
* `System.Char`/`char`
* Literal is denoted by a single-quote, e.g., `'a'`
* Can be cast to integral type
  * *Implicit* cast to `ushort`
  * *Explicit* cast to others

+++
## Boolean type
* `System.Boolean`/`bool`
* Store logical values
  * `true` or `false`

```C#
sizeof(bool) == sizeof(uint8) == sizeof(sbyte)
```

* Nothing can be casted to `bool`
* Operators:
  * Equality `==`, `!=`
  * Conditional operators `&&`, `||`

```C#
public bool UseUmbrella(bool rainy, bool sunny, bool windy) {
  return !windy && (rainy || sunny);
}
```
* Often used for the *Lazy evaluation*
```C#
public static Foo Foo => _foo ?? (_foo = new Foo()); //later explained
```

+++
### Enum
* Used for enumerations
* **Do not use magic values!**
* Default size is `int`, can be changed to `byte`, `sbyte`, etc...

```C#
enum Foo {
  none,
  one,
  two,
  ten = 10
}
```

+++
### Struct
* Similar to a class type
* Unlike classes, *structs* are **value types** and do not typically require heap allocation
* Struct types **do not** support
  * User-specified *inheritance*
  * Struct types implicitly inherit from type `System.ValueType` that inherits `System.Object`

```C#
struct Foo
{
  string foo;
}
```

+++
## Nullable value types
* **Do not have to be assigned** *before they can be accessed*
* Because they are reference types, thus their `default` value is `null`
* For each non-nullable value type `T` there is a corresponding nullable value type `System.Nullable<T>`, `T?`
  * With the same value range as `T` + **additional value** - `null`

```C#
int  ten = 10;
int? one = 1;
int? canBeNull = null;
int  cannotBeNull = null;      // Compile-time error
```

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/NullableType.cs&lang=C#&title=Nullable Type Sample
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/NullableType.cs)


+++
##  Reference types
@snap[north-east span-10]
![](/Lectures/Lecture_01/Assets/img/Overview_small.png)
@snapend
* **Class types**
  * Ultimate base class of all other types: `object`
  * Unicode strings: `string`
  * User-defined types of the form `class C {...}`
* **Interface types**
  * User-defined types of the form `interface I {...}`
* **Array types**
  * Single- and multi-dimensional, e.g., `int[]` and `int[,]`
* **Delegate types**
  * User-defined types of the form `delegate int D(...)`
* **Generics**
  * Parameterized with other types `MyGenericType<T>`

+++
### Class
* **Data structure** that contains:
  * Data members - *fields*
  * Function members - *methods*, *properties*, *events*, *indexers*, *user-defined operators*, *instance constructors*, *static constructors*, *destructors*
* Supports
  * **Single, transitive, inheritance**
  * Polymorphism
* Extends and specializes base class/es

```C#
class @Class{}

class Foo
{
  string foo;
}
```

+++
### Interface
* Think about it as a **contract**
* Named set of *public function members*
* A **class** or **struct** that **implements an interface** *must provide implementations of the interface’s function members*
* An **interface can inherit** *from multiple base interfaces*, and a **class or struct can implement** *multiple interfaces*

```C#
interface IInterface
{
  string FirstName { get; }
  string LastName { get; }
  string GetFullName();
}
```


+++
### Delegate
* **References to methods** with a *particular parameter list* and *return type*
* Method can be treated as an entity that can be assigned to variable and passed as a parameter
* Analogous to **function type** provided by *functional languages*
  * They are also similar to the **concept of function pointers** found in other languages
  * Unlike function pointers, delegates are object-oriented and **type-safe**

```C#
public delegate int PerformCalculation(int x, int y);

class MyClass
{
  PerformCalculation PerformCalculation = Sum;

  void CallDelegate()
  {
    PerformCalculation(1, 2);
  }

  static int Sum(int x, int y) => x + y;
}
```

+++
### String
* `System.String` / `string`
* Represents *sequence of characters*
* **Reference** data type
* Always *immutable*
* Literal is denote by double-quotes. e.g., `"string value"`
* Verbatim string is denote by `@` prefix, e.g.,
```C#
@"Multi-line
string"
```

+++
#### String concatenation
* `+` operator
* Not all operands need to be strings
* Non-string operands get called `ToString()` method on them
```C#
string s = "a" + 5; // a5
```
* For multiple string concatenation operations avoid usage of `+`, use:
  * `System.Text.StringBuilder`
  * `s = System.String.Format("{0} times {1} = {2}", i, j, (i*j));`
  * `s = $"{i} times {j} = {i*j}";`

+++
### Array
* Represents *fixed length data structure of homogeneous items*
* Stored in a sequential block of memory
* *Do not have to be declared before it can be used*
* **Initialization**
  * Value types - default value
  * Reference types - `null`
* Access out of array range throws `IndexOutOfRangeException`
* Array types are constructed by following a type name with square brackets
  * `int[]` *single-dimensional* array of int
  * `int[,]` *two-dimensional* array of int (matrix)
  * `int[][]` is a *single-dimensional array of single-dimensional* array of int

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Array.cs&lang=C#&title=Array Sample
@[11-21]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Array.cs)

---
### Variables
* Has a specific **type**, which determines:
  * The **size** and layout of the memory
  * The **range of values** that can be stored within that memory
  * The **set of operations** that can be applied

+++
#### Variable types

<table>
<thead>
<tr>
<th>Type</th>
<th>Value</th>
</tr>
</thead>
<tbody>
<tr>
<td><strong>Non-nullable</strong> type</td>
<td><em><ul>
  <li>value of that </em>exact type</li>
</ul></td>
</tr>
<tr>
<td><strong>Nullable</strong>  type</td>
<td><ul>
<li>null<em> value </li>
<li>value of that </em>exact type</li>
</ul></td>
</tr>
<tr>
<td><strong>Object</strong></td>
<td><ul>
<li><em>null</em> reference</li>
<li>reference to an <em>object</em> of any reference type</li>
<li>reference to a <em>boxed value</em> of any value type</li>
</ul></td>
</tr>
<tr>
<td><strong>Class</strong> type</td>
<td><ul>
<li><em>null</em> reference</li>
<li>reference to an <em>instance of that class</em> type</li>
<li>reference to an instance of a class <em>derived</em> from that class type</li>
</ul></td>
</tr>
<tr>
<td>⋮</td>
<td>⋮</td>
</tr>
</tbody>
</table>

+++
#### Variable types
<table>
<thead>
<tr>
<th>Type</th>
<th>Value</th>
</tr>
</thead>
<tbody>
<td><strong>Interface</strong> type</td>
<td><ul>
<li><em>null</em> reference</li>
<li>reference to an <em>instance of a class</em> type that <em>implements</em> that interface type</li>
<li>reference to a <em>boxed</em> value of a value type that implements that interface type</li>
</ul></td>
</tr>
<tr>
<td><strong>Array</strong> type</td>
<td><ul>
<li><em>null</em> reference</li>
<li>reference to an <em>instance of that array</em> type</li>
<li>reference to an <em>instance of a compatible array</em> type</li>
</ul></td>
</tr>
<tr>
<td><strong>Delegate</strong> type</td>
<td><ul>
<li><em>null</em> reference</li>
<li>reference to an <em>instance of a compatible delegate</em> type</li>
</ul></td>
</tr>
</tbody>
</table>


+++
### Stack vs Heap
* **Stack**
  * Allocated block of memory for *local variables, parameters, return values*
* **Heap**
  * Storage for *reference data types, static variables*
  * Managed by the *Garbage Collector*
* Therefore:
  * **Local variable** has to be *assigned before reading*
  * **Method** has to be *called with all arguments*
  * **All other** values are initialized automatically

+++
### Default values
|    Type   | Default value  |
| --------- | -------------- |
| Reference | `null`         |
| Numerical | `0`            |
| Enums     | `0`            |
| Char      | `'\0'`         |
| Boolean   | `false`        |

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/DefaultValue.cs&lang=C#&title=Default Value Sample
@[12-18]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/DefaultValue.cs)

---
## Parameters
* Parameters can be passed to a method as:
  * **Value**
  * **Ref** reference
    * Variable **may** *be modified* by the called method
  * **In** reference
    * Variable **cannot** *be modified* by the called method
  * **Out** reference
    * Variable **must** *be assigned* by the called method
    * Variable **need not** *to be initialized* before the method call

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/ValueParameter.cs&lang=C#&title=Value Parameter Sample
@[9-26]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/ValueParameter.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/RefParameter.cs&lang=C#&title=Ref Parameter Sample
@[7-17]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/RefParameter.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/InParameter.cs&lang=C#&title=In Parameter Sample
@[7-19]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/InParameter.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/OutParameter.cs&lang=C#&title=Out Parameter Sample
@[7-24]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/OutParameter.cs)

+++
### Parameter with `params[]`
* Can be used only as the *last parameter* in a method signature
* Has to be declared as an array
* Used to pass multiple variables of the same type

```C#
int Sum(params int[] items)
{
  return items.Sum();
}
```

```C#
var one   = Sum(1);
var two   = Sum(1, 2);
var three = Sum(1, 2, 3);
```

+++
### Optional parameters
* Has a default value as a part of its definition
* If omitted, the *default value* is used

```C#
void Foo(int x = 2, int y = 3) { … }
```
```C#
Foo();
Foo(1);
Foo(1, 2);
```

+++
### Named parameters
* Usually used with method calls on methods with *multiple optional parameters*
* Reduce the number of *method overrides*

```C#
void Foo(int x = 2, int y = 3) { … }
```
```C#
Foo(y:4, x:4);
Foo(y: ++a, x: --a);
Foo(y: 1);
```

---
## Operators
* Types
  * *unary* e.g. `++x, sizeof(int), +x, (int)x`
  * *binary* e.g. `x + y`
  * *ternary* e.g. `(input > 0) ? "positive" : "negative"`
* *Binary* operators use **infix** notation, operator is in between operands
* **Primary expression**
  * Used to build the language
  * `Math.Log(1)` contains two primary operators `.` and `()`
* [List of all operators](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/operators)

+++
## Expressions
* Usually, **returns some value** after computation
* The simplest expression is *constant* or *variable*, e.g., `5`
* Expression can be combined using operators

```C#
5*4
```

* If you are not sure about priority, use '()'
```C#
(5*4)+1
```

+++
### Void expressions
* *Do not have value*
* Cannot be combined with other operators
* E.g., `{}, return, etc...`

```C#
Expression<Action> tree = () => Console.WriteLine("Hello");
Expression<Action> tree2 = () => { Console.WriteLine("Hello"); }; // Compile-time error
```

* [An expression may be classified as] "nothing". 
  * This occurs when the expression is an *invocation of a method with a return type of void*. 
  * An expression classified as nothing *is only valid in the context of a statement expression*.

+++
### Assigning expression
* E.g., `x=x+5`
* Can be part of another expression
```C#
y = 5 * (x = 2);
```
* Can be used to initialize multiple variables:
```C#
a = b = c = d = e = 0;
```
* Combination of operators
  * `x+=5`, the same meaning as `x=x+5`

+++
### Priority and assignment
* Priority is evaluated by the *priority of operators*
* *The same priority* operators are evaluated starting with *the most left one*
* Left-associative operators
  * `8/4/2` equals `(8/4)/2`
* Right-associative operators
```C#
x = y = 3;
```

---
## Statements - Selection
* Used to define a program control flow
* `if`
* `switch`
* Conditional (ternary) operand `?:`

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/If.cs&lang=C#&title=If Sample
@[10-17]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/If.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Switch.cs&lang=C#&title=Switch Sample
@[13-30]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Switch.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Switch.cs&lang=C#&title=Switch Sample C# 8
@[45-64]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Switch.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/TernaryOperand.cs&lang=C#&title=Ternary Operand Sample
@[10-12]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/TernaryOperand.cs)

+++
## Statements - Cycles
* `while`
* `do while`
* `for`
* `foreach`


+++?code=/Lectures/Lecture_01/Assets/sln/Tests/While.cs&lang=C#&title=While Sample
@[10-16]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/While.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/DoWhile.cs&lang=C#&title=Do While Sample
@[10-15]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/DoWhile.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/For.cs&lang=C#&title=For Sample
@[10-13]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/For.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/ForEach.cs&lang=C#&title=Foreach Sample
@[10-14]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/ForEach.cs)

+++
## Statements - Jump statements
* `break`
* `continue`
* `return`
* `throw`
* `goto`
  * usage leads to [Spaghetti code](https://en.wikipedia.org/wiki/Spaghetti_code)


+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Break.cs&lang=C#&title=Break Sample
@[10-20]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Break.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Continue.cs&lang=C#&title=Continue Sample
@[10-17]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Continue.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Return.cs&lang=C#&title=Return Sample
@[8-12]
@[17-20]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Return.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Throw.cs&lang=C#&title=Throw Sample
@[8-18]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Throw.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Goto.cs&lang=C#&title=Goto Sample
@[10-17]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Goto.cs)

+++
## Statements - other
* `using`
  * Encapsulates the use of a disposable resource
* `lock`
  * For *safe access* to the resource from the concurrent context
  * Simplification of a *Monitor synchronization primitive*

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Using.cs&lang=C#&title=Using Sample
@[10-13]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Using.cs)

+++?code=/Lectures/Lecture_01/Assets/sln/Tests/Lock.cs&lang=C#&title=Lock Sample
@[11-22]
@[24-35]
[Code sample](/Lectures/Lecture_01/Assets/sln/Tests/Lock.cs)

---
## Namespaces
* *Groups classes and interfaces to named groups*
* Namespace `System.Security.Cryptography` contains class, e.g., RSA
* Usage of types from a given namespace, e.g.,
```C#
System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
```

* Directive `using`
```C#
using System.Security.Cryptography;
public class Namespaces
{
  public void Method()
  {
    RSA rsa = RSA.Create(); // Don't need fully qualified name
  }
}
```

+++
### Keyword `namespace`

```C#
namespace Outer.Middle.Inner
{
  class Class1 { ... }
  class Class2 { ... }
}
```

* Same as:

```C#
namespace Outer
{
  namespace Middle
  {
    namespace Inner
    {
      class Class1 { ... }
      class Class2 { ... }
    }
  }
}
```

+++
### Namespaces - rules
* Names declared in an outer scope are implicitly imported into inner one

```C#
namespace Outer
{
  namespace Middle
  {
    internal class Class1 { ... }

    namespace Inner
    {
      internal class Class2 : Class1 { ... }
    }
  }
}
```

+++
### Repetition of namespaces
* Namespace name can be repeated until a collision of names of inner types occurs
* The same namespace can be declared in multiple places

```C#
namespace Outer.Middle.Inner
{
  class Class1 {}
}
```
```C#
namespace Outer.Middle.Inner
{
  class Class2 { }
}
```

+++
### Inner `using` directives
* `using` can be used in an inner namespace to limit its scope

```C#
namespace N1
{
  class Class1 { }
}
namespace N2
{
  using N1;
  class Class2 : Class1 { }
}
namespace N2
{
  class Class3 : Class1 { } // Compile-time error
}
```

---
## References:

[C# 8.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-8-0-Nutshell-Definitive-Reference/dp/1492051136)
[Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio)
[Microsoft Visual Studio](https://visualstudio.microsoft.com)
[Microsoft](https://www.microsoft.com)
[Resharper](https://www.jetbrains.com/resharper)
[Wikipedia](https://en.wikipedia.org)
[Programiz](https://www.programiz.com)
[C# in depth](http://csharpindepth.com)

+++
## Refences to used images:
[Amazon books](https://www.amazon.com/)
[Welcome to the Visual Studio IDE](https://docs.microsoft.com/en-us/visualstudio/ide/visual-studio-ide?view=vs-2017)
[Why Choose .NET?](https://www.microsoft.com/net/platform/why-choose-dotnet)
[Wikipedia .Net Framework](https://en.wikipedia.org/wiki/.NET_Framework)
[CLR In Process](https://scottdorman.github.io/2008/11/10/clr-4.0-in-process-side-by-side-clr-hosting/)
[CodeProject Improve garbage collector performance](https://www.codeproject.com/Articles/39246/NET-Best-Practice-No-2-Improve-garbage-collector)
[C# 8.0 in a Nutshell](http://www.albahari.com/nutshell/)
[.NET Core, .NET Framework, Xamarin](https://blogs.msdn.microsoft.com/cesardelatorre/2016/06/27/net-core-1-0-net-framework-xamarin-the-whatand-when-to-use-it/)

+++

## Credits
* Michal Orlíček - for slides preparation

---

---?include=/Lectures/Lecture_01/Assets/csharp-version-history.md
