@snap[north span-100]
# .NET Standard and Language Integrated Query (LINQ)
@snapend

@snap[midpoint span-100]
## .NET Standard libraries, collections, MSSQL, XML
@snapend

@snap[south-east span-60]
[ Tibor Jašek <tibor.jasek@gmail.com>, Patrik Švikruha ]
@snapend

---
## .NET Standard
* Formal specification of .NET APIs
* Intended to be available on all .NET implementations
* Establishes greater uniformity in the .NET ecosystem
* [.NET Standard github](https://github.com/dotnet/standard)
* [Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### .NET Standard enables
* Uniform **set of APIs** for all .NET implementations to implement, independent of workload
* Produce **portable libraries** that are *usable across .NET implementations*, using same set of APIs
* **Reduces conditional compilation** of *shared source* due to .NET APIs

+++
#### .NET Yesterday

![](/Lectures/Lecture_03/Assets/img/NetYesterday.png)

+++
#### .NET Today

![](/Lectures/Lecture_03/Assets/img/NetToday.png)


+++
#### .NET Tomorrow

![](/Lectures/Lecture_03/Assets/img/NetTomorrow.png)

+++
### .NET Standard vs .NET Core
* **.NET Standard**
  * *specification* that *covers which APIs a .NET platform has to implement*
* **.NET Core**
  * **concrete .NET platform**
  * *implements the .NET Standard*

+++
### .NET Standard versions
* Higher versions **incorporate** all APIs from previous versions
* Once shipped, **versions are frozen**
* Specific .NET platform to .NET Standard
  * .NET Standard *version depends on which version of .NET Standard platform is implementing*
* .NET Standard version choice
  * The higher the version, the more APIs are available to you
  * The lower the version, the more platforms you can run on

+++
#### .NET Standard Version Table

![](/Lectures/Lecture_03/Assets/img/NetStandardVersionTable.png)

+++
### Why .NET Standard 2.0 instead of 1.7?
* More than **doubled the API surface**
  * Added a compatibility shim that allows **referencing of existing binaries**
    * Even if they weren't built against *.NET Standard*

+++
### .NET Standard Version Growing

| Version |  #APIs | Growth % |
|:--------|-------:|---------:|
| 1.0     |  7,949 |          |
| 1.1     | 10,239 |     +29% |
| 1.2     | 10,285 |      +0% |
| 1.3     | 13,122 |     +28% |
| 1.4     | 13,140 |      +0% |
| 1.5     | 13,355 |      +2% |
| 1.6     | 13,501 |      +1% |
| 2.0     | 32,638 |    +142% |
| 2.1     | 37,118 |     +14% |

+++
### .NET API
* [.NET Standard API](https://docs.microsoft.com/sk-sk/dotnet/api/?view=netstandard-2.0)
* **API**(Application programming interface):
  * **Set of namespaces**(*classes*, *structs*, *interfaces*, *enums*, *delegates*)
  * Allows the creation of applications which access the features or data of an:
    * Operating system
    * Application
    * Other service..

---
## `System` Namespace
* `using System`
* [Documentation](https://docs.microsoft.com/sk-sk/dotnet/api/system?view=netstandard-2.0)
* **Fundamental classes and base classes**
* **Defines:**
  * *Commonly-used value and reference data types*
  * *Events and event handlers*
  * *Interfaces*
  * *Attributes*
  * *Processing exceptions*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Data types
* `class Object` - ultimate base class of all classes in the .NET
* `class String` - represents a String
* `class Array` -  represents an Array
* `class Delegate` - represents a delegate
* `class Enum` - base class for enumerations
* `class Tuple` - provides methods for creating tuple objects

+++
## Sctruct types
* `struct Boolean`
* `struct Byte`, `struct SByte`
* `struct Char`
* `struct DateTime`
* `struct Decimal`, `struct Double`
* `struct Guid`
* `struct Int16`, `struct Int32`, `struct Int64`, `struct IntPtr`
* `struct UInt16`, `struct UInt32`, `struct UInt64`, `struct UIntPtr`
* `struct Nullable<T>`
* `struct void`


+++
## Type
* `class Type`
* Represents **type declarations**
  * *class* types
  * *interface* types
  * *array* types
  * *value* types
  * *enumeration* types
  * *type* parameters
  * *generic type* definitions

```C#
Type type = typeof(String);

MethodInfo methodInfo =
type.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

Object result = methodInfo.Invoke("Hello, World!", new Object[] { 7, 5 });
Console.WriteLine("{0} returned \"{1}\".", methodInfo, result);
```

+++
## ValueType
* `class ValueType`
* Provides the **base class for value types**

```C#
public static bool IsFloat(ValueType value)
{
    return (value is float | value is double | value is Decimal);
}
```

+++
## Convert
* `class Convert`
* Converts a **base data type to another base data type**

```C#
try {
  int intNumber = System.Convert.ToInt32(fooNumber);
}
catch (System.OverflowException) {
  System.Console.WriteLine(
    "Overflow in double to int conversion.");
}
```

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/ConvertTest.cs&lang=C#&title=Convert Sample
@[9-21]
@[12,17]
@[13,18]
@[14,19]
@[15,20]
@[9-21]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/Convert.cs)

+++
## Bit Converter
* `class BitConverter`
* **Converts:**
  * *Base data types* to an *array of bytes*
    * `GetBytes(Boolean)`, `GetBytes(Int32)` `GetBytes(Char)`...
  * *Array of bytes* to *base data types*
    * `ToBoolean(Byte[], Int32)`, `ToInt32(Byte[], Int32)`, `ToChar(Byte[], Int32)`...

```C#
bool sample = true;
byte[] sampleByteArray = BitConverter.ToString(BitConverter.GetBytes(sample);
Console.WriteLine(BitConverter.ToString(sampleByteArray)); //01
```

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/BitConverterTest.cs&lang=C#&title=Bit Converter Sample
@[9-16]
@[11]
@[12]
@[13]
@[15]
@[9-16]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/BitConverterTest.cs)

+++
## URI
* **Uniform Resource Identifier**
  * String that **identifies a particular resource**
  * Predefined set of syntax rules

![](/Lectures/Lecture_03/Assets/img/UriSyntax.png)

+++
### URI examples

```URI
          userinfo     host        port
          ┌─┴────┐ ┌────┴────────┐ ┌┴┐
  https://john.doe@www.example.com:123/forum/questions/?tag=networking#top
  └─┬─┘ └───────┬────────────────────┘└─┬─────────────┘└──┬──────────┘└┬─┘
  scheme     authority                 path              query     fragment

  ldap://[2001:db8::7]/c=GB?objectClass?one
  └─┬┘ └───────┬─────┘└─┬─┘ └──────┬──────┘
 scheme    authority  path       query

  mailto:John.Doe@example.com
  └──┬─┘ └─────────┬────────┘
  scheme         path

  tel:+1-816-555-1212
  └┬┘ └──────┬──────┘
scheme     path

  telnet://192.0.2.16:80/
  └──┬─┘ └──────┬──────┘│
  scheme    authority  path
```

+++
### URI Standard
* `class Uri`- representation of URI
* `UriBuilder` - custom URI constructors
* Other classes:
  * `UriFormatException`, `UriTypeConverter`, `FtpStyleUriParser`, `HttpStyleUriParser`...
* Enums:
  * `UriComponents`, `UriFormat`, `UriHostNameType`...

```C#
var uri = new Uri("http://www.contoso.com/");
WebRequest webRequest = WebRequest.Create(uri);
```

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/UriTest.cs&lang=C#&title=Uri Sample
@[9-15]
@[11,12]
@[14]
@[9-15]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/UriTest.cs)

+++
## Console
* `class Console` - **standard input, output, and error streams** for console applications
* Struct:
  * `ConsoleKeyInfo`
* Enums:
  * `ConsoleKey`, `ConsoleSpecialKey`, `ConsoleSpecialKey`...

```C#
Console.WriteLine("Prints on ");
Console.WriteLine("New line");

Console.Write("Prints on ");
Console.Write("Same line");

Console.ReadLine();
```

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/ConsoleSample.cs&lang=C#&title=Console Sample
@[7-20]
@[9]
@[11-12,19]
@[13]
@[15-16]
@[18]
@[7-20]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/ConsoleSample.cs)

+++
## Garbage Collector
* `class GC`
* **Controls garbage collector**
  * Service that **automatically reclaims unused memory**

```C#
void MakeSomeGarbage()
{
    for(int i = 0; i < 1000; i++)
    {
        var o = new Object();
    }
}

MakeSomeGarbage();
GC.Collect();
```

+++
## Math
* `class Math`
* Provides constants and static methods for
  * Trigonometric *mathematical functions*
  * Logarithmic *mathematical functions*
  * Other common *mathematical functions*

```C#
double circleRadius = 4.2;
double circlePerimeter = ((2 * Math.PI) * circleRadius);
double circleArea = Math.PI * (Math.Pow(circleRadius, 2));
```

+++
## Random
* `class Random`
* Represents a **pseudo-random number generator**
* Device that produces a sequence of numbers that meet certain statistical requirements for randomness

```C#
Random random = new Random();
for (var i = 1; i <= 10; i++)
    Console.WriteLine("{0,15:N0}", random.Next());
// The example output
//         1,733,189,596
//           566,518,090
//         1,166,108,546
//         1,931,426,514
//         1,341,108,291
//         1,012,698,049
//           890,578,409
//         1,377,589,722
//         2,108,384,181
//         1,532,939,448
```

+++
## Version
* `class Version`
* Represents the **version number** of
  * *Assembly*
  * *Operating system*
  * *Common language runtime*

```C#
// Get the operating system version.
OperatingSystem operatingSystem = Environment.OSVersion;
Version version = operatingSystem.Version;
Console.WriteLine("Operating System: {0} ({1})", operatingSystem.VersionString, version.ToString());
```

```C#
// Get the common language runtime version.
Version version = Environment.Version;
Console.WriteLine("CLR Version {0}", version.ToString());
```

+++
## Other important classes
* `class Buffer` - manipulates arrays of primitive types
* `class Environment` - information about the current environment and platform
* `class Lazy<T>` - support for lazy initialization
* `class StringComparer` - represents a string comparison operation
* `class Attribute` - represents the base class for custom attributes
* `class SerializableAttribute` - indicates that a class can be serialized
* `class Nullable` - supports a value type that can be assigned null e.g. `int?`
* `class WeakReference` - references an object while still allowing that object to be reclaimed by GC

+++
## `System` Namespace Exceptions
* **50+ basic exceptions**
  * `class Exception` - base class for all exceptions
  * `class SystemException` - base class for system exceptions
  * ⋮

+++
## Action and Func delegates
* **Action** -  method that **does not return a value**
```C#
delegate void Action(); //has no parameters
delegate void Action<in T>(T obj); //has one parameter
delegate void Action<in T1,in T2>(T1 arg1, T2 arg2); //has two parameters
⋮
```

* **Func** - method that **returns a value** of the type specified by the TResult parameter
```C#
delegate TResult Func<out TResult>(); //has no parameters
delegate TResult Func<in T,out TResult>(T arg); //has one parameter
delegate TResult Func<in T1,in T2,out TResult>(T1 arg1, T2 arg2); //has two params
⋮
```

+++
## Event handlers
* Methods that will handle an *event*
  * `delegate void EventHandler(object sender, EventArgs e)`
    * Event that has **no data**
  * `delegate void EventHandler<TEventArgs>(object sender, TEventArgs e)`
    * Event that **provides data**
  * `delegate void ConsoleCancelEventHandler(object sender, ConsoleCancelEventArgs e)`
  * `delegate System.Reflection.Assembly ResolveEventHandler(object sender, ResolveEventArgs args)`
  * `delegate void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)`
  * ⋮

+++
## Other important delegates
* `delegate int Comparison<in T>(T x, T y)`
  * Method that **compares** two objects of the same type
* `delegate void AsyncCallback(IAsyncResult ar)`
  * Method to be called when a corresponding **asynchronous operation completes**
* `delegate TOutput Converter<in TInput,out TOutput>(TInput input)`
  * Method that **converts** an object from one type to another type

---
## Collections
* **List**
  * Stores values in list
  * *Grows automatically*
* **Dictioniary**
  * Stores *key and value* pairs
* **Stack**
  * Stores the values in *Last In First Out* style
* **Queue**
  * Stores the values in *First In First Out* style
* **Set**
  * *Non-duplicate* elements

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Generic vs non-generic collections
* **Recommended to use generic collections**
  * **Type safety**
  * **Better performance** (no need to box the elements)

|  Non-generic variant | Generic variant |
|:- |:- |
| `ArrayList` | `List<T>` |
| `SortedList` | `SortedList<TKey,TValue>` |
| `Hashtable` | `Dictionary<TKey,TValue>` |
| `Queue` | `Queue<T>` |
| `Stack` | `Stack<T>` |

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Iterfaces Hierarchy
![](/Lectures/Lecture_03/Assets/img/CollectionHierarchy.png)

+++
## `System.Collections` Namespace
* `using System.Collections`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=netstandard-2.0)
* Contains interfaces and classes that define various collections
* **Define**:
  * *Lists*
  * *Queues*
  * *Bit arrays*
  * *Hash tables*
  * *Dictionaries*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## ArrayList
* `class ArrayList`
* Using an array whose **size is dynamically increased** as required
* Implements the `IList` interface
  * `interface IList`
  * Defines **non-generic collection** of objects that can be individually accessed by index

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/ArrayListSample.cs&lang=C#&title=ArrayList Sample
@[8-25]
@[11-14]
@[17-19]
@[21-24]
@[8-25]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/ArrayListSample.cs)

+++
## Stack
* `class Stack`
* Simple **last-in-first-out non-generic collection** of objects
* Implements the `ICollection` interface
  * `interface ICollection`
  * Defines *size*, *enumerators*, and *synchronization* methods for all nongeneric collections
* Implements the `IEnumerable` interface
  * `interface IEnumerable`
  * Exposes an *enumerator*, which supports a simple iteration over a non-generic collection

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/StackSample.cs&lang=C#&title=Stack Sample
@[8-24]
@[11-14]
@[17-18]
@[20-23]
@[8-24]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/StackSample.cs)

+++
## Queue
* `class Queue`
* **First-in, first-out collection** of objects
* Implements the `ICollection` interface
* Implements the `IEnumerable` interface

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/QueueSample.cs&lang=C#&title=Queue Sample
@[8-24]
@[11-14]
@[17-18]
@[20-23]
@[8-24]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/QueueSample.cs)

+++
## Hashtable
* `class Hashtable`
* **Collection of key/value pairs** that are organized by the hash code of the key
* Implements the `IDictionary` interface
  * `interface IDictionary`
  * Nongeneric collection of key/value pairs

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/HashtableTest.cs&lang=C#&title=Hashtable Sample
@[10-24]
@[13, 17-21]
@[22]
@[23]
@[10-24]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/HashtableTest.cs)

+++
## Other Collections
* `class BitArray`
  * Compact **array of bit values**, which are represented as Booleans
* `class SortedList`
  * **Collection of key/value pairs** that are **sorted** by the keys

```C#
bool[] boolArray = new bool[5] { true, false, true, true, false };
BitArray bitArray = new BitArray( boolArray );

foreach ( var bit in bitArray ) {
    Console.Write(bit);
}
```

```C#
SortedList sortedList = new SortedList();
sortedList.Add("Third", "!");
sortedList.Add("Second", "World");
sortedList.Add("First", "Hello");
```

+++
## Base classes
* collection `abstract` **base classes**:
  * `class CollectionBase` - for a strongly typed collection
  * `class DictionaryBase` - for a strongly typed collection of key/value pairs
  * `class ReadOnlyCollectionBase` - for a strongly typed non-generic read-only collection

---
## `System.Collections.Generic` Namespace
* `using System.Collections.Generic`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netstandard-2.0)
* Contains **interfaces and classes** that define **generic collections**
* Allow users to create **strongly typed** collections
  * Provide *better type safety and performance*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Generic List
* `class List<T>`
* **Strongly typed** list of objects that can be accessed by index
* Provides methods to
  * Search
  * Sort
  * Manipulate
* **Type Parameter** `T`
  * The type of elements in the list
* `class SortedList<TKey,TValue>`
  * Key/value pairs that are sorted by key based on the associated `IComparer<T>` implementation
  * `class IComparer<T>`

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/GenericListTest.cs&lang=C#&title=Generic List Sample
@[9-18]
@[21-27]
@[30-36]
@[39-44]
@[47-54]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/GenericListTest.cs)

+++
## Generic Stack
* `class Stack<T>`
* Variable size
* **Last-in-first-out** collection
  * Instances of the **same specified type**

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/GenericStackTest.cs&lang=C#&title=Generic Stack Sample
@[9-19]
@[11-16]
@[18]
@[9-19]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/GenericStackTest.cs)

+++
## Generic Queue
* `class Queue<T>`
* Variable size
* **First-in, first-out** collection
* Collection of instances of the **same specified type**

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/GenericQueueTest.cs&lang=C#&title=Generic Queue Sample
@[9-19]
@[11-16]
@[18]
@[9-19]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/GenericQueueTest.cs)

+++
## Generic Dictionary
* `class Dictionary<TKey,TValue>`
* Variable size
* **First-in, first-out** collection
* Collection of instances of the **same specified type**
* `class Dictionary<TKey,TValue>.KeyCollection`
  * Collection of keys in dictionary
* `class Dictionary<TKey,TValue>.ValueCollection`
  * Collection of values in dictionary
* `class SortedDictionary<TKey,TValue>`
  * Dictionary that is sorted on the key
* **Type Parameters**
  * `TKey` - the type of the keys in the dictionary
  * `TValue` - the type of the values in the dictionary

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/GenericDictionaryTest.cs&lang=C#&title=Generic Dictionary Sample
@[9-20]
@[11-16]
@[18-19]
@[9-20]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/GenericDictionaryTest.cs)

+++
## HashSet
* `class HashSet<T>`
* **Set** of values
* `ISet<T>` | Define methods for generic sets |
| `IReadOnlyCollection<T>` | Define methods for generic read-only collections |
| `IReadOnlyDictionary<TKey,TValue>` | Define methods for generic read-only dictionaries |
| `IReadOnlyList<T>` | Define methods for generic read-only lists |
| `IComparer<T>` | Defines a method that a type implements to compare two objects |
| `IEnumerable<T>` | Exposes the enumerator, which supports a simple iteration over a collection of a specified type |


---
## `System.IO` Namespace
* `using System.IO`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netstandard-2.0)
* Types that provide **file and directory support**
* Types that allow **reading** and **writing to files**
  * Data streams

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Path
  * `class Path`
  * *Operations* on `string` instances that contain file or directory path information
  * Performed in a cross-platform manner

```C#
string path1 = @"c:\temp\MyTest.txt";
string path2 = @"c:\temp\MyTest";
string path3 = @"temp";

if (Path.HasExtension(path1))
{
    Console.WriteLine("{path1} has an extension.");
}

if (!Path.HasExtension(path2))
{
    Console.WriteLine("{path2} has no extension.");
}

Console.WriteLine($"The full path of {path3} is {Path.GetFullPath(path3)}.");
Console.WriteLine($"{Path.GetTempPath()} is the location for temporary files.");
Console.WriteLine($"{Path.GetTempFileName()} is a file available for use.");
```

+++
## Static vs Instance
* Classes that provides static methods
  * **Directory**
  * **File**
* Classes that provides properties and instance methods
  * **FileSystemInfo** (`abstract` base class)
    * **DirecoryInfo**
    * **FileInfo**
* *Static methods* perform *security checks on all methods*
* For **one action** a **static variant** is better than an instance one
* For **reuse** an **instance one** is better, because the security check will not always be necessary

+++
## Directory and File
* `class Directory` and `class File`
* `static` methods
* **Directory**
  * *Creating*, *moving*, *deleting*, *renaming*, *copying* directories
  * *Enumerating* through subdirectories and subfiles
* **File**
  * *Creating*, *moving*, *deleting*, *renaming* *copying* files
  * *Opening* and *appending* to a file
  * Creation of `FileStream` objects

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/DirectorySample.cs&lang=C#&title=Directory Sample
@[8-21]
@[10-11]
@[13-20]
@[8-21]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/DirectorySample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/FileSample.cs&lang=C#&title=File Sample
@[8-16]
@[10]
@[12-13]
@[15]
@[8-16]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/FileSample.cs)

+++
## DirecoryInfo and FileInfo
* `class DirectoryInfo` and `class FileInfo`
* Properties and instance methods
* **DirectoryInfo**
  * *Creating*, *moving*, *deleting*, *renaming*, *copying* directories
  * *Enumerating* through subdirectories and subfiles
* **File**
  * *Creating*, *moving*, *deleting*, *renaming* *copying* files
  * *Opening* and *appending* to a file
  * Creation of `FileStream` objects

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/DirectoryInfoSample.cs&lang=C#&title=DirectoryInfo Sample
@[8-34]
@[10-11]
@[12-13,29-33]
@[14-20]
@[22-24]
@[26-28]
@[8-34]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/DirectoryInfoSample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/FileInfoSample.cs&lang=C#&title=FileInfo Sample
@[8-20]
@[10]
@[12-13]
@[15-16]
@[18-19]
@[8-20]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/FileInfoSample.cs)

+++
## Data Streams
* `Stream Class`
* Abstract base class of all streams
* **Abstraction of a sequence of bytes**, such as
    * *File*
    * *Input/output device*
    * *Inter-process communication pipe*
    * *TCP/IP socket*
    * ⋮
* **Fundamental operations**
  * *Reading* - transfer of data from a stream into a data structure,
  * *Writing* - transfer of data from a data structure into a stream.
  * *Seeking*(optional) - querying and modifying the current position within a stream

+++
## File Stream
* `class FileStream`
* Stream for a file
* **Synchronous** and **asynchronous**
* **Read** and **write** operations

```C#
using (FileStream fileStream = File.OpenRead(@"c:\test.txt"))
{
    byte[] b = new byte[1024];
    UTF8Encoding encoding = new UTF8Encoding(true);
    while (fileStream.Read(b,0,b.Length) > 0)
    {
        Console.WriteLine(encoding.GetString(b));
    }
}
```

+++
## Stream Writer and Stream Reader
* `class StreamWriter` and `class StreamReader`
* Reads characters from a byte stream
* Writes characters to a stream
* In a **particular encoding**

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/StreamWriterSample.cs&lang=C#&title=StreamWriter Sample
@[8-30]
@[10-11, 23-29]
@[12-15, 22]
@[16-21]
@[8-30]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/StreamWriterSample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/StreamReaderSample.cs&lang=C#&title=StreamReader Sample
@[8-31]
@[10-11, 24-30]
@[12-15, 23]
@[16-22]
@[8-31]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/StreamReaderSample.cs)

+++
## Other readers and writers
|  Class | Description |
|:-:|:- |
| `StringReader` | Reads from a string |
| `StringWriter` | Writes to a string(stored in `StringBuilder`) |
| `TextReader` | Reads a sequential series of characters(`abstract`) |
| `TextWriter` | Writes a sequential series of characters(`abstract`) |
| `BinaryReader` | Reads primitive data types as binary values in a specific encoding |
| `BinaryWriter` | Writes primitive types in binary to a stream and supports writing strings in a specific encoding |

+++
## `System.IO.Pipes` Namespace
* `using System.IO.Pipes`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.io.pipes?view=netstandard-2.0)
* Types that provide means for interprocess communication through anonymous and/or named pipes
* **Synchronous** and **asynchronous read** and **write** operations
* `class PipeStream` - base class for Pipes
  * `class NamedPipeServerStream` - server side of a named pipe stream
  * `class NamedPipeClientStream` - client side of a named pipe stream
  * `class AnonymousPipeServerStream` - server side of an anonymous pipe stream
  * `class AnonymousPipeClientStream` - client side of an anonymous pipe stream

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/PipeServerSample.cs&lang=C#&title=PipeServer Sample
@[9-38]
@[11-12]
@[14]
@[16-18]
@[20]
@[23-29]
@[9-38]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/PipeServerSample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/PipeClientSample.cs&lang=C#&title=PipeClient Sample
@[9-34]
@[11-12]
@[15-17]
@[19-21]
@[22-30]
@[9-34]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/PipeClientSample.cs)

---
## `System.Numerics` Namespace
* `using System.Numerics`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.numerics?view=netstandard-2.0)
* **Numeric types** that complement the numeric primitives

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## BigInteger
* `struct BigInteger`
* Nonprimitive integral type that supports **arbitrarily large integers**
* Has *no lower or upper bound*
* Can contain the value of any integer

```C#
BigInteger number = BigInteger.Pow(UInt64.MaxValue, 3);
Console.WriteLine(number);

// The example displays the following output:
// 6277101735386680762814942322444851025767571854389858533375
```

+++
## Complex
* `struct Complex`
* Represents a **complex number**

```C#
Complex complex1 = new Complex(12, 6);
Complex complex2 = 3.14;
Complex complex3 = (Complex) 12.3m;
Complex complex4 = Complex.Pow(Complex.One, -1);
Complex complex5 = Complex.One + Complex.One;

Console.WriteLine(c1);
Console.WriteLine(c2);
Console.WriteLine(c3);
Console.WriteLine(c4);
Console.WriteLine(c5);

// The example displays the following output:
// (12, 6)
// (3.14, 0)
// (12.3, 0)
// (1, 0)
// (2, 0)
```

---
## `System.Reflection` Namespace
* `using System.Reflection`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.reflection?view=netstandard-2.0)
* Contains types that **retrieve information** about *assemblies*, *modules*, *members*, *parameters*, and other entities in managed code by examining their metadata
* **Manipulate instances of loaded types**

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/ReflectionTest.cs&lang=C#&title=Reflection Sample
@[8-14]
@[19-25]
@[21]
@[23-24]
@[19-25]
@[28-38]
@[30-32]
@[34-37]
@[28-38]
@[41-48]
@[43-45]
@[47]
@[41-48]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/ReflectionTest.cs)

+++
## Dynamic type
* **Escapes type checking at compile time**
* It **resolves type at run time**
* Dynamic type can be defined using the `dynamic` keyword
* Methods can have dynamic type parameters

```C#
dynamic x = "c#";
x++;
x.FakeMethod();
```

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/DynamicParameter.cs&lang=C#&title=Dynamic Parameter Sample
@[5-27]
@[7-10]
@[12-19]
@[21-26]
@[5-27]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/DynamicParameter.cs)

+++
## Reflection vs. Dynamic
* Both used when we want **operate on an object during runtime**
* *dynamic* uses *reflection* internally

|  | Reflection | Dynamic |
|:- |:-:|:-:|
|Inspect (meta-data) | Yes | No |
|Invoke public members | Yes | Yes |
|Invoke private members | Yes | No |
|Caching | No | Yes |
|Static class | Yes | No |


![ReflectionVSDynamic](/Lectures/Lecture_03/Assets/img/ReflectionVSDynamic.jpg)

---
## `System.Text` Namespace
* `using System.Text`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text?view=netstandard-2.0)
* Classes that **represent** ASCII and Unicode character **encodings**
  * Abstract base classes for *converting blocks of characters to and from blocks of bytes*
* Helper class that manipulates and formats `String` objects without creating intermediate instances of `String`

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Encoding
* `class Encoding`
* `abstract`
* process of **transforming a set of Unicode characters into a sequence of bytes**
* **Provides the following implementations:**
  * `class ASCIIEncoding`
  * `class UTF7Encoding`
  * `class UTF8Encoding`
  * `class UnicodeEncoding`
  * `class UTF32Encoding`
* **Decoder**
  * `class Decoder`
  * `abstract`
  * Converts a *sequence of encoded bytes into a set of characters*

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/EncodingSample.cs&lang=C#&title=EncodingSample Sample
@[10]
@[12-14]
@[16-17]
@[19-20]
@[22-25]
@[27-29, 31-33]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/EncodingSample.cs)

+++
## StringBuilder
* `class StringBuilder`
* **String-like object** whose value is a **mutable** sequence of characters
  * Maintains a *buffer* to accommodate expansions to the string
  * New data is appended to the *buffer* if room is available; otherwise, a new, larger *buffer* is allocated

+++
### String vs. StringBuilder
* *Each operation that appears to modify a `String` object actually creates a new string*
* **`String` is better when**
  * **Number of changes** that your app will make to a string **is small**
  * App is performing a **fixed number of concatenation operations**
    * Compiler might combine them into single one
  * App performs **extensive search operations** while building string
    * E.g. `IndexOf`, `StartWith`
* **`StringBuilder` is better when**
  * App makes an **unknown number of changes** to a string at design time
    * E.g. loop to concatenate a random number of strings that contain user input
  * When you expect your app to make a **significant number of changes** to a string

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/StringBuilderTest.cs&lang=C#&title=StringBuilder Sample
@[9-28]
@[11-13]
@[15-16]
@[18-19]
@[21-22]
@[24-25]
@[27]
@[9-28]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/StringBuilderTest.cs)

---
## `System.Text.RegularExpressions` Namespace
* `using System.Text.RegularExpressions`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions?view=netstandard-2.0)
* [Online regex tester](http://regexstorm.net/tester)
* Provide access to the .NET Framework regular expression engine
* **Regex Class**
  * `class Regex`
  * Represents an immutable regular expression

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Regex Sample
* **For example`\b(?<word>\w+)\s+(\k<word>)\b`**
  * Regular expression to check for repeated occurrences of words in a string
  * Can be interpreted as:

| Pattern | Description |
|:-:|:- |
| `\b` | Start the match at a word boundary |
| `(?<word>\w+)` | Match one or more word characters up to a word boundary. Name this captured group `word` |
| `\s+` | Match one or more white-space characters |
| `(\k<word>)` | Match the captured group that is named `word` |
| `\b` | Match a word boundary |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/RegexTest.cs&lang=C#&title=Regex Sample
@[10-27]
@[12-14]
@[16-17]
@[19-20]
@[22-26]
@[10-27]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/RegexTest.cs)

---
## `System.Linq` Namespace
* `using System.Linq`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=netstandard-2.0)
* Classes and interfaces that support queries that use **Language-Integrated Query** (LINQ)
* The `Enumerable` class contains LINQ standard query operators that operate on objects that implement `IEnumerable<T>`
* The `Queryable` class contains LINQ standard query operators that operate on objects that implement `IQueryable<T>`

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Language integrated query
* **Type safety**
* **Lazy Evaluation**
* **Syntaxes**
  * **Fluent** - using extension methods
  * **Query** - using keywords

+++
### Fluent syntax
```C#
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
IEnumerable<string> query = names
  .Where(n => n.Contains("a"))
  .OrderBy(n => n.Length)
  .Select(n => n.ToUpper());

foreach (string name in query) Console.WriteLine(name);
```

![LinqFluentSyntax](/Lectures/Lecture_03/Assets/img/LinqFluentSyntax.png)

+++
### Query syntax diagram

```C#
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
    from n in names
    where n.Contains("a") // Filter elements
    orderby n.Length // Sort elements
    select n.ToUpper(); // Translate each element (project)
```

+++
### Query syntax diagram

@img[span-50](/Lectures/Lecture_03/Assets/img/LinqQuerySyntax.png)

+++
### Fluent vs Query syntax
* Each has its own benefits
* Can be combinated
* Some operators exists only in **Fluent syntax**
* **Query syntax** is better
  * When `let` is used to create new variable in query
  * When using `SelectMany`, `Join`, `GroupJoin` with inner variable
* **Fluent syntax** is better
  * When using just one operator

+++
### Subqueries
* It is possible to use LINQ query inside LINQ query

```C#
var musos = { "David Gilmour", "Roger Waters", "Rick Wright",
	"Nick Mason" };
```

Fluent syntax
```
IEnumerable<string> query = musos.OrderBy(m => m.Split().Last());
```

Query syntax
```
var query = from m in musos
    orderby m.Split().Last()
    select m;
```

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqMaterializationTest.cs&lang=C#&title=LINQ Materialization Sample
@[10-20]
@[12]
@[14-15]
@[17]
@[19]
@[10-20]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqMaterializationTest.cs)

+++
### LINQ Operators
* Can be split by **input and output** into three categories

|  IN |  | OUT |
| -:|:-:|:- |
| Sequence in | -> | Sequence out |
| Sequence in | -> | Single element or scalar value out |
| Nothing in | -> | Sequence out |

+++
### LINQ Filtering Operators
Filtering is an operation to restrict the result set to the point where it shows only selected elements satisfying a particular condition.

| Operator | Description |
|:-:|:- |
| `Where` | Filter values based on a predicate function |
| `OfType` | Filter values based on their ability to be as a specified type |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqFilteringOperatorsTest.cs&lang=C#&title=LINQ Filtering Operators Sample
@[10-16]
@[12-13]
@[15]
@[10-16]
@[19-25]
@[21-22]
@[24]
@[19-25]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqFilteringOperatorsTest.cs)

+++
### LINQ Join Operators
Joining refers to an operation which directly targets data sources with difficult to follow relationships with each other in a direct way.
<!-- Toto je dosť nezrozumiteľné. -->

| Operator | Description |
|:-:|:- |
| `Join` | The operator join two sequences on basis of matching keys |
| `GroupJoin` | Join two sequences and group the matching elements |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqJoinOperatorsTest.cs&lang=C#&title=LINQ Join Operators Sample
@[11-34]
@[13-18]
@[20-25]
@[27-30]
@[32-33]
@[11-34]
@[36-40]
@[42-46]
@[49-69]
@[51-52]
@[54-57]
@[59-60]
@[62-63]
@[65-68]
@[49-69]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqJoinOperatorsTest.cs)

+++
### LINQ Projection Operators
Projection is an operation in which an object is transformed into an altogether new form with only specific properties.

| Operator | Description |
|:-:|:- |
| `Select` | The operator projects values on basis of a transform function |
| `SelectMany` | The operator projects the sequences of values which are based on a transform function as well as flattens them into a single sequence |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqProjectionOperatorsTest.cs&lang=C#&title=LINQ Projection Operators Sample
@[10-23]
@[12]
@[14]
@[16-18]
@[20-22]
@[10-23]
@[26-44]
@[28-29]
@[31-35]
@[37-43]
@[26-44]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqProjectionOperatorsTest.cs)

+++
### LINQ Sorting Operators
A sorting operation allows ordering the elements of a sequence on basis of a single or more attributes.

| Operator | Description |
|:-:|:- |
| `OrderBy` | The operator sorts values in an ascending order |
| `OrderByDescending` | The operator sorts values in a descending order |
| `ThenBy` | Executes a secondary sorting in an ascending order |
| `ThenByDescending` | Executes a secondary sorting in a descending order |
| `Reverse` | Performs a reversal of the order of the elements in a collection |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqSortingOperatorsTest.cs&lang=C#&title=LINQ Sorting Operators Sample
@[9-16]
@[11-12]
@[14-15]
@[9-16]
@[19-26]
@[21-22]
@[24-25]
@[19-26]
@[29-36]
@[31-32]
@[34-35]
@[29-36]
@[39-49]
@[41-42]
@[44-45]
@[47-48]
@[39-49]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqSortingOperatorsTest.cs)

+++
### LINQ Grouping Operators
The operators put data into some groups based on a common shared attribute.

| Operator | Description |
|:-:|:- |
| `GroupBy` | Organize a sequence of items in groups and return them as an `IEnumerable` collection of type `IGrouping<key, element>` |
| `ToLookup` | Execute a grouping operation in which a sequence of key pairs is returned |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqGroupingOperatorsTest.cs&lang=C#&title=LINQ Grouping Operators Sample
@[9-29]
@[11]
@[13]
@[15-16,28]
@[17-18,27]
@[19-26]
@[9-29]
@[32-43]
@[34]
@[36]
@[38-42]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqGroupingOperatorsTest.cs)

+++
### LINQ Conversion Operators
The operators change the type of input objects and are used in a diverse range of applications.

| Operator | Description |
|:-:|:- |
| `AsEnumerable` | Returns the input typed as `IEnumerable<T>` |
| `AsQueryable` | A (generic) `IEnumerable` is converted to a (generic) `IQueryable` |
| `Cast` | Performs casting of elements of a collection to a specified type |
| `OfType` | Filters values on basis of their type, depending on their capability to be cast to a particular type |
| `ToArray` | Forces query execution and does conversion of a collection to an array |
| `ToDictionary` | On basis of a key selector function transforms elements into a `Dictionary<TKey, TValue>` and forces execution of a LINQ query |
| `ToList` | Forces execution of a query by converting a collection to a `List<T>` |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqConversionsOperatorsTest.cs&lang=C#&title=LINQ Conversions Operators Sample
@[13-20]
@[15]
@[17]
@[19]
@[13-20]
@[23-30]
@[25]
@[27]
@[29]
@[23-30]
@[33-41]
@[35]
@[37]
@[39-40]
@[33-41]
@[44-51]
@[46]
@[48]
@[50]
@[44-51]
@[54-61]
@[56]
@[58]
@[60]
@[54-61]
@[64-77]
@[66-71]
@[73]
@[75-76]
@[64-77]
@[80-87]
@[82]
@[84]
@[86]
@[80-87]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqConversionsOperatorsTest.cs)

+++
### LINQ Concatenation Operators
Performs concatenation of two sequences and is quite similar to the Union operator in terms of its operation except for the fact that this does not remove duplicates.

| Operator | Description |
|:-:|:- |
| `Concat` | Two sequences are concatenated into a single one. |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqConcatenationOperatorTest.cs&lang=C#&title=LINQ Concatenation Operator Sample
@[9-19]
@[11-12]
@[14]
@[16-18]
@[9-19]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqConcatenationOperatorTest.cs)

+++
### LINQ Aggregation Operators
Performs any type of desired aggregation and allows creating custom aggregations in LINQ.

| Operator | Description |
|:-:|:- |
| `Aggregate` | Operates on the values of a collection to perform custom aggregation operation |
| `Average` | Average value of a collection of values is calculated	 |
| `Count` | Counts the elements satisfying a predicate function within collection |
| `LongCount` | Counts the elements satisfying a predicate function within a huge collection |
| `Max` | Find out the maximum value within a collection |
| `Min` | Find out the minimum value existing within a collection |
| `Sum` | Calculate the sum of values within a collection |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqAggregationOperatorsTest.cs&lang=C#&title=LINQ Aggregation Operators Sample
@[10-17]
@[12]
@[14]
@[16]
@[10-17]
@[20-27]
@[22]
@[24]
@[26]
@[20-27]
@[30-37]
@[32]
@[34]
@[36]
@[30-37]
@[40-48]
@[42-43]
@[45]
@[47]
@[40-48]
@[51-58]
@[53]
@[55]
@[57]
@[51-58]
@[61-68]
@[63]
@[65]
@[67]
@[61-68]
@[71-78]
@[73]
@[75]
@[77]
@[71-78]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqAggregationOperatorsTest.cs)

+++
### LINQ Quantifier Operators
These operators return a Boolean value when some or all elements within a sequence satisfy a specific condition.

<!-- Any a Contains sú strašne krkolomné -->
| Operator | Description |
|:-:|:- |
| `All` | Returns `True` if all elements of a sequence satisfy a predicate condition |
| `Any` | Determines by searching a sequence that whether any element of the same satisfy a specified condition |
| `Contains` | Returns `True` if finds that a specific element is there in a sequence if the sequence doe not contains that specific element , `false` is returned |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqQuantifierOperationsTest.cs&lang=C#&title=LINQ Quantifier Operators Sample
@[9-14]
@[11]
@[13]
@[9-14]
@[17-22]
@[19]
@[21]
@[17-22]
@[25-30]
@[27]
@[29]
@[25-30]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqQuantifierOperationsTest.cs)

+++
### LINQ Partition Operators
Divide an input sequence into two parts without rearranging the elements of the sequence and then return one of them.

| Operator | Description |
|:-:|:- |
| `Skip` | Skips some specified number of elements within a sequence and returns the remaining ones |
| `SkipWhile` | Same as Skip with exception that the number of elements to skip is specified by a condition |
| `Take` | Take a specified number of elements from a sequence and skip the remaining ones |
| `TakeWhile` | Same as Take except that the number of elements to take is specified by a condition |


+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqPartitionOperatorsTest.cs&lang=C#&title=LINQ Partition Operators Sample
@[9-19]
@[11]
@[13]
@[15-18]
@[9-19]
@[22-32]
@[24]
@[26]
@[28-31]
@[22-32]
@[35-45]
@[37]
@[39]
@[41-44]
@[35-45]
@[48-58]
@[50]
@[52]
@[54-57]
@[48-58]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqPartitionOperatorsTest.cs)

+++
### LINQ Generation Operators
A new sequence of values is created by generational operators.

| Operator | Description |
|:-:|:- |
| `DefaultIfEmpty` | When applied to an empty sequence, generate a default element within a sequence |
| `Empty` | Returns an empty sequence of values and is the simplest generational operator |
| `Range` | Generates a collection having a sequence of integers or numbers |
| `Repeat` | Generates a sequence of a specific length containing repeated values |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqGenerationOperationsTest.cs&lang=C#&title=LINQ Generation Operators Sample
@[9-18]
@[11-13]
@[15-17]
@[9-18]
@[21-26]
@[23]
@[25]
@[21-26]
@[29-37]
@[31]
@[33-36]
@[29-37]
@[40-51]
@[42-43]
@[45]
@[47-50]
@[40-51]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqGenerationOperationsTest.cs)

+++
### LINQ Set Operators
There are four operators for the set operations, each yielding a result based on different criteria.
<!-- Toto prakticky nič nehovorí -->

| Operator | Description |
|:-:|:- |
| `Distinct` | Returns a list of unique values from a collection by filtering duplicate data if any |
| `Except` | Compares the values of two collections and returns the ones from one collection which are not in the other collection |
<!-- (A - B)? (B - A)? nedeterministické? -->
| `Intersect` | Returns the set of values contained in both collections |
| `Union` | Combines content of two different collections into a single list without any duplicate content |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqSetOperationsTest.cs&lang=C#&title=LINQ Set Operators Sample
@[9-16]
@[11]
@[13]
@[15]
@[9-16]
@[19-29]
@[21-22]
@[24]
@[26-28]
@[19-29]
@[32-41]
@[34-35]
@[37]
@[39-40]
@[32-41]
@[44-52]
@[46-47]
@[49]
@[51]
@[44-52]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqSetOperationsTest.cs)

+++
### LINQ Equality
Compares two sequences (enumerable) and determines if they are an exact match or not.

| Operator | Description |
|:-:|:- |
| `SequenceEqual` | Results a Boolean value if two sequences are found to be identical to each other |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqEqualityOperatorsTest.cs&lang=C#&title=LINQ Equality Operator Sample
@[10-26]
@[12-15]
@[17-20]
@[22-25]
@[10-26]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqEqualityOperatorsTest.cs)

+++
### LINQ Element Operators
#### Part 1
All standard query element operators return a single element from a collection.

| Operator | Description |
|:-:|:- |
| `ElementAt` | Returns an element present at a specific index in a collection |
| `ElementAtOrDefault` | Same as `ElementAt` except that it also returns a default value in case the specific index is out of range |
| `First` | Retrieves the first element of a collection or the first element satisfying a specific condition |
| `FirstOrDefault` | Same as `First` except that it also returns a default value in case there is no existence of such elements |

+++
### LINQ Element Operators
#### Part 2

| Operator | Description |
|:-:|:- |
| `Last` | Retrieves the last element present in a collection or the last element satisfying a specific condition |
| `LastOrDefault` | Same as `Last` except that it also returns a default value in case there is no existence of any such element |
| `Single` | Returns the lone element of a collection or the lone element that satisfies a certain condition |
| `SingleOrDefault` | Same as `Single` except that it also returns a default value if there is no such element |

+++?code=/Lectures/Lecture_03/Assets/sln/Tests/LinqElementOperatorsTest.cs&lang=C#&title=LINQ Element Operators Sample
@[10-17]
@[12]
@[14]
@[16]
@[10-17]
@[20-29]
@[22]
@[24-25]
@[27-28]
@[20-29]
@[32-37]
@[34]
@[36]
@[32-37]
@[40-47]
@[42-43]
@[45-46]
@[40-47]
@[50-55]
@[52]
@[54]
@[50-55]
@[58-65]
@[60-61]
@[63-64]
@[58-65]
@[68-77]
@[70-72]
@[74-76]
@[68-77]
@[80-89]
@[82-84]
@[86-88]
@[80-89]
[Code sample](/Lectures/Lecture_03/Assets/sln/Tests/LinqElementOperatorsTest.cs)

+++
### How implement LINQ?
* [TUTORIAL - Create your own LINQ implementation](http://codeblog.jonskeet.uk/category/edulinq/)
* E.g. `Where`:

```C#
public static IEnumerable<TSource> Where<TSource>(
	this IEnumerable<TSource> source, Func<TSource, bool> predicate)
{
    // Check of input parameters ...
    foreach (TSource item in source)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}
```

+++
## LINQ to SQL
* *ORM* - Object Relational Mapper
* *LINQ* query to *SQL* query

```C#
// using System.Data.Common;
Northwnd db = new Northwnd(@"c:\northwnd.mdf");

var q =
    from cust in db.Customers
    where cust.City == "London"
    select cust;

Console.WriteLine("Customers from London:");
foreach (var z in q)
{
    Console.WriteLine("\t {0}",z.ContactName);
}

DbCommand dc = db.GetCommand(q);
Console.WriteLine("\nCommand Text: \n{0}",dc.CommandText);
Console.WriteLine("\nCommand Type: {0}",dc.CommandType);Combines content of two different collections into a single list without any duplicate content.
Console.WriteLine("\nConnection: {0}",dc.Connection);
```

+++
### Output
```SQL
Customers from London:
    Thomas Hardy
    Victoria Ashworth
    Elizabeth Brown
    Ann Devon
    Simon Crowther
    Marie Bertrand
    Hari Kumar
    Dominique Perrier

Command Text:
SELECT [t0].[CustomerID], [t0].[CompanyName], [t0].[ContactName], [t0].[ContactT
itle], [t0].[Address], [t0].[City], [t0].[Region], [t0].[PostalCode], [t0].[Coun
try], [t0].[Phone], [t0].[Fax]
FROM [dbo].[Customers] AS [t0]
WHERE [t0].[City] = @p0

Command Type: Text

Connection: System.Data.SqlClient.SqlConnection
```

+++
## LINQ to...
* LINQ to **Entity framework** - next lecture
* LINQ to Paralel LINQ (PLINQ)
* LINQ to NHibernate
* LINQ to Sharepoint
* LINQ to ActiveDirectory
* LINQ to JSON
* LINQ to SNMP
* LINQ to Wikipedia
* LINQ to Twitter
* LINQ to FQL (Facebook Query Language)

---
## eXtensible Markup Language (XML)
* Readable for both humans and machines
* Stricter version of *HTML*
* **Storing and transporting data**

```XML
<gesmes:Envelope>

<Cube>
    <Cube time="2019-02-05">
    <Cube currency="USD" rate="1.1423"/>
    <Cube currency="JPY" rate="125.59"/>
    <Cube currency="BGN" rate="1.9558"/>
    <Cube currency="CZK" rate="25.697"/>
    <Cube currency="DKK" rate="7.4650"/>
    <Cube currency="GBP" rate="0.87803"/>
```

+++
## XML namespaces
* `System.Xml` Namespace
  * `using System.Xml`
  * [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.xml?view=netstandard-2.0)
  * Provides standards-based support for processing XML
* `System.Xml.Linq` Namespace
  * `using System.Xml.Linq`
  * [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.xml.linq?view=netstandard-2.0)
  * Classes for LINQ to XML
* `System.Xml.XPath` Namespace
  * `using System.Xml.XPath`
  * [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xpath?view=netstandard-2.0)
  * Define a cursor model for navigating and editing XML
* `System.Xml.Resolvers` Namespace
* `System.Xml.Schema` Namespace
* `System.Xml.Serialization` Namespace
* `System.Xml.Xsl` Namespace

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## XmlDocument vs XmlReader/Writer
* `class XmlDocument`
 *  Represents an **XML document**
 *  Used to **load**, **validate**, **edit**, **add**, and **position** XML in a document
 *  Loads the **whole XML document into memory** to process
* `class XmlReader` and `class XmlWriter`
  * **Stream based**
  * **Fast, non-cached, forward-only**
  * Reader provides **access** to XML data
  * Writer provides way to **generate streams or files** that contain XML data


+++?code=/Lectures/Lecture_03/Assets/sln/Examples/XmlReaderSample.cs&lang=C#&title=Reading XML with the XmlReader class
@[8-20]
@[10]
@[11-12, 18]
@[13-14, 17]
@[15-16]
@[8-20]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/XmlReaderSample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/XmlDocumentReadSample.cs&lang=C#&title=Reading XML with the XmlDocument class
@[8-15]
@[10]
@[11]
@[12-13]
@[8-15]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/XmlDocumentReadSample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/XmlWriterSample.cs&lang=C#&title=Writing XML with the XmlWriter class
@[7-25]
@[9]
@[11-12]
@[14-17]
@[19-21]
@[23-24]
@[7-25]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/XmlWriterSample.cs)

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/XmlDocumentWriteSample.cs&lang=C#&title=Writing XML with the XmlDocument class
@[8-29]
@[10]
@[11-12]
@[14-19]
@[21-26]
@[28]
@[8-29]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/XmlDocumentWriteSample.cs)

+++
## Reading XML with the XPath input
```XML
<bookstore>
    <book genre="autobiography" publicationdate="1981-03-22" ISBN="1-861003-11-0">
        <title>The Autobiography of Benjamin Franklin</title>
        <author>
            <first-name>Benjamin</first-name>
            <last-name>Franklin</last-name>
        </author>
        <price>8.99</price>
    </book>
    <book genre="novel" publicationdate="1967-11-17" ISBN="0-201-63361-2">
        <title>The Confidence Man</title>
        <author>
            <first-name>Herman</first-name>
            <last-name>Melville</last-name>
        </author>
        <price>11.99</price>
    </book>
    <book genre="philosophy" publicationdate="1991-02-15" ISBN="1-861001-57-6">
        <title>The Gorgias</title>
        <author>
            <name>Plato</name>
        </author>
        <price>9.99</price>
    </book>
</bookstore>
```

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/XPathSample.cs&lang=C#&title=Reading XML with the XPath Sample
@[8-23]
@[10-11]
@[13-15]
@[17]
@[19-20]
@[8-23]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/XPathSample.cs)


+++
## XML Serialization
* `System.Xml.Serialization` Namespace
* Classes that are **used to serialize objects into XML and back**
* E.g:

```XML
<StepList>
  <Step>
    <Name>Name1</Name>
    <Desc>Desc1</Desc>
  </Step>
  <Step>
    <Name>Name2</Name>
    <Desc>Desc2</Desc>
  </Step>
</StepList>
```

+++?code=/Lectures/Lecture_03/Assets/sln/Examples/XmlSerialization.cs&lang=C#&title=Xml Serialization Sample
@[7-12]
@[14-20]
@[24-42]
@[26-35]
@[37]
@[38-41]
@[24-42]
[Code sample](/Lectures/Lecture_03/Assets/sln/Examples/XmlSerialization.cs)

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)
[Microsoft documentation](https://docs.microsoft.com)
[Microsoft documentation github](https://github.com/MicrosoftDocs)
[.NET Standard web](http://immo.landwerth.net)
[.NET Standard github](https://github.com/dotnet/standard)
[Tutorials Point](https://www.tutorialspoint.com)
[Regex Storm](http://regexstorm.net/tester)
[Wikipedia](https://en.wikipedia.org)

+++
## Refences to images used:
[.NET Standard version table](http://immo.landwerth.net/netstandard-versions/)
[Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)
[Stanford University](https://www.stanford.edu/)

+++
## Credits
* Michal Orlíček - for slides preparation
