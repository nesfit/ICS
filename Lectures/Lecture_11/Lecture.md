---
title: ICS 11 - Parallel programming
css: _reveal-md/theme.css
theme: simple
separator: "^---$"
verticalSeparator: "^\\+\\+\\+$"
highlightTheme: "vs"
---

# Parallel programming
## Process, thread, and task in .NET perspective

<div class="right">[ Jan Pluskal &lt;pluskal@vut.cz&gt;  ]</div>

---

## Lecture outline:  
1. Motivation
2. Parallel programming
3. Asynchronous programming


---

## Serial computing

![Serial computing](assets/diagrams-SerialComputing.png)

---

## Parallel computing

![Parallel computing](assets/diagrams-ParallelComputing.png)

---

## Parallel computing

- Concurrent processing / Running multiple things at once
- May increase performance **if used appropriately**
- Achieved by:
    - Multiple **processes**
    - Multiple **threads**

---

## Synchronous vs. asynchronous computing

- Synchronous execution
    - *I/O operation, long running computation* blocks execution

- Asynchronous execution
    - Non-blocking execution
    - "*I don't wait, I get notified*"

---

## Asynchronous computing

![Asynchronous computing](https://eloquentjavascript.net/img/control-io.svg)

Source: https://eloquentjavascript.net/11_async.html

---

# Parallel programming

---

## Process 

- known from IOS
- **standalone** running program
- has its process identification (PID)
- **does not share code and variables** with other processes
- needs OS for synchronization (mutexes, ...)
- needs OS for data sharing (shared memory, ...)
- STDIN/STDOUT/STDERR

---

## Thread

- runs **within a process**
- **has its own stack but shares a heap**
- error in one thread can kill the whole process
- **shares code and variables** with other threads
- needs RUNTIME synchronization mechanisms (locking, ...)
- data are shared between threads using heap (needs protection)

---

## Thread vs. Process

![Thread vs Process](https://techdifferences.com/wp-content/uploads/2017/01/Multithreading.jpg)

Source:https://techdifferences.com/difference-between-multiprocessing-and-multithreading.html

---

## Process in .NET

- represented by [`Process`](https://docs.microsoft.com/cs-cz/dotnet/api/system.diagnostics.process?view=netcore-2.2) class

```C#
using var process = new System.Diagnostics.Process
{
    StartInfo =
    {
        FileName = "ping", 
        Arguments = "8.8.8.8", 
        RedirectStandardOutput = true
    }
};

process.Start();
// do some work....
process.WaitForExit();
```

---

## Process in .NET

- Input/Output
    - accessing output via events:
        - `ErrorDataReceived` - output written to `stderr`
        - `OutputDataReceived` - output written to `stdout`
    - need to be enabled via `BeginOutputReadLine()` or `BeginErrorReadLine()`
- allows opening of file with associated executable
    - Set `FileName` to associated file and set `UseShellExecute` to `true`


```C#
var lineCount = 0;
var output = new StringBuilder();
process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
{
    // Prepend line numbers to each line of the output.
    if (!string.IsNullOrEmpty(e.Data))
    {
        lineCount++;
        output.Append("\n[" + lineCount + "]: " + e.Data);
    }
});
process.Start();
process.BeginOutputReadLine();
```

---

## Process in .NET

- accesing input via `StandardInput` property

```C#
using var process = new System.Diagnostics.Process ...
process.Start();
process.StandardInput.WriteLine("Hello world");
```

---

## Process in .NET

- Exiting
    - handled via `WaitForExit` method and its overloads
    - initiated via `Close` method
    - when needed `Kill` method can be used to force termination

---

## DEMO: Process

---

## Threads in .NET

- represented via `Thread` class
- possible to get current `Thread` using `Thread.CurrentThread`
- should never be created directly! Use `ThreadPool` instead.
- for waiting `Join()` method is present

---

## ThreadPool in .NET

- `ThreadPool` class [documentation](https://docs.microsoft.com/cs-cz/dotnet/api/system.threading.threadpool?view=netcore-2.2)
- uses *pool* design pattern
- manages recycling and planning of thread executions
- can be configured (methods `SetMaxThreads()`/`SetMinThread()`)

```C#

public static void Main() 
{
    ThreadPool.QueueUserWorkItem(ThreadProc);
}

static void ThreadProc(Object stateInfo) 
{
    Console.WriteLine("Hello from the thread pool.");
}

```

---

## DEMO: Threads

---

## Parallel programming issues

![Multithread meme](https://img.devrant.com/devrant/rant/r_346573_4iGrA.jpg)

---

## Parallel programming issues

- shared resources
- read/write synchronization
- exceptions handling in threads
- UI thread access
- debugging multiple threads
- deadlock


---

## Read-write synchronization

```C#
class Counter {
    
    int Count { get; private set; }= 0;

    public void Increment() {
        //Critical section
        var count = Count + 1;
        Count = count;
        //End of critical section
    }
}
```
---

## Read-write synchronization

```C#
account = new Counter()
T1:account.Increment();
T2:account.Increment();

T1: var count = Count + 1;  // Count = 0
T2: var count = Count + 1   // Count = 0
T1: Count = count           // Count = 1
T2: Count = count           // Count = 1
```

---

# DEMO: Thread synchronization issues

---

## Synchronization mechanisms

|         Method         |            Purpose            | Supports processes | Overhead |
| :--------------------: | :---------------------------: | :----------------: | :------: |
|         `lock`         |     Denies mutual access      |                    |   20ns   |
|        `Mutex`         |     Denies mutual access      |         X          |  1000ns  |
|    `SemaphoreSlim`     |     Allows n-time access      |                    |  200ns   |
|      `Semaphore`       |     Allows n-time access      |         X          |  1000ns  |
| `ReaderWriterLockSlim` | Reader-writer synchronization |                    |   40ns   |
|   `ReaderWriterLock`   | Reader-writer synchronization |                    |  100ns   |

Only `SemaphoreSlim` is reasonable to use in **async** context.

---

## Synchronization mechanisms examples

```C#
private IList<FriendModel> friendsList;
private static object addFriendLock = new object(); 
public void AddFriend(FriendModel friend)
{
    lock(addFriendLock) {
        friendsList.Add(friend);
    }
}
```

---

## Synchronization mechanisms examples

```C#
private IList<FriendModel> friendsList;
private static SemaphoreSlim addFriendSemaphore = new SemaphoreSlim(1); 
public void AddFriend(FriendModel friend)
{
    try
    {
        addFriendSemaphore.Wait();
        friendsList.Add(friend);
    }
    finally 
    {
        addFriendSemaphore.Release();
    }
}
```

---

## Synchronized collections 

- provided in namespace `System.Collections.Concurrent`
    - `BlockingCollection<T>` - ordered collection
    - `ConcurrentQueue<T>` - queue
    - `ConcurrentBag<T>` - unordered collection 
    - `ConcurrentStack<T>` - stack

---

# DEMO: Synchronization fixing

---

## Task Parallel Library

- TPL [Documentation](https://docs.microsoft.com/cs-cz/dotnet/standard/parallel-programming/task-parallel-library-tpl)
    - parallel `For` and `ForEach` implementation
    - PLINQ - parallel implementation of LINQ queries - `AsParallel` method
- Be careful! Parallel does not always mean faster!

```C#
//Parallel ForEach 
Parallel.ForEach(sourceCollection, item => Handle(item));
//PLINQ
source.AsParallel()
      .Where(n => n % 10 == 0)
      .Select(n => n);
```

---

# DEMO: Task Parallel Library

---

# Asynchronous programming

---

## Asynchronous programming in C# 

- three options:
    - Asynchronous Programming Model (APM)
    - Event-based Asynchronous Pattern (EAP)
    - Task-based Asynchronous Pattern (TAP)

---

## Asynchronous Programming Model

- for each operation, we define `AsyncCallback` object
- this object defines a method that should be called when the operation ends
- the method accepts [`IAsyncResult`](https://docs.microsoft.com/cs-cz/dotnet/api/system.iasyncresult?view=netframework-4.7.2) parameter


```C#
private delegate int AddDelegate(int x, int y);

public int Add(int x, int y) 
{
    return x+y;
}

AddDelegate operation = Add;
operation.BeginInvoke(5, 5, new AsyncCallback(AddCompleted), null);

public void AddCompleted(IAsyncResult result) 
{
    //Handle completion here
    Console.WriteLine($"Is completed {result.IsCompleted}")
}
```

---

## Event-based Asynchronous Pattern

- communication between the caller and the method is done via `event`s
- typically used on UI components for retrieving results of UI operations

```C#
OperationProvider provider = new OperationProvider ();
provider.DoOperationAsync ("some state data");
provider.DoOperationCompleted += Provider_DoOperationCompleted;

public void Provider_DoOperationCompeted(string result) 
{
    Console.WriteLine(result);
}
```

---

## Task-based Asynchronous Pattern

- in C\# represented with `Task` class or `Task<T>`
- `Task` is a representation of an operation that is running asynchronously
- asynchronous methods return `Task` instead of `void` or `Task<T>` instead of `T`
- when method returning `Task` is called the methods starts executing, but the caller method continues as well (unless waiting for task completion)
- empty task can be get via `Task.CompletedTask` or `Task.FromResult()`
- important properties
    - `Status` - running/waiting/faulted/ran
    - `Result` - `null` when running, value when finished
    - `Exception` - thrown exception

---

## Task-based Asynchronous Pattern


![Task running diagram](https://i.stack.imgur.com/asvWD.png)
[Fullsize](https://i.stack.imgur.com/asvWD.png)

---

## Support in .NET

- I/O handling classes
    - `StreamReader`, `StreamWriter`- for streams and files access
    - `HttpClient`, `WebClient` - for accessing web resources

---

## Task management

- `Task.WhenAll()` - waiting for multiple tasks to finish
- `GetAwaiter().GetResult()` - returns the (result|throws exception) of task in synchronous code
- `await task` - returns the (result|throws exception) of task in asynchronous code
- `ContinueWith(Task t)` - task chaining

---

## async/await

- syntactic constructs for better working with `Task`s

```C#
public async Task<int> LoadResult(INetwork network)
{
    var data = await network.LoadData();
    return data.Sum();
}
```

---

## async/await

- method marked `async` has to be `void` or return `Task`
- returning `Task` is preferrable
- `await` can be used only inside methods marked as `async`
- if `Task` is not awaited the execution will continue

```C#
public async Task AddFriendButtonClicked() 
{
    await friendFacade.AddFriend(SelectedFriend);
}

class FriendFacade : IFriendFacade {
    public Task AddFriend(FriendModel model) {
        ...
    }
}
```

---


# DEMO: `async`/`await`

---

<!-- Has to stay, because otherwise static build would not contain logo resources referenced in CSS theme -->
![](_reveal-md/img/logo-ics.svg)
+++
![](_reveal-md/img/logo.png)
