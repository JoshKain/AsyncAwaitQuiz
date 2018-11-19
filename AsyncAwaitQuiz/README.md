
### Task,  Task\<T\>, Thread and ThreadPool classes in C#

**Thread**

Thread represents an actual OS-level thread, with its own stack and kernel resources. (technically, a CLR implementation could use fibers instead, but no existing CLR does this) Thread allows the highest degree of control; you can Abort() or Suspend() or Resume() a thread (though this is a very bad idea), you can observe its state, and you can set thread-level properties like the stack size, apartment state, or culture.

The problem with Thread is that OS threads are costly. Each thread you have consumes a non-trivial amount of memory for its stack, and adds additional CPU overhead as the processor context-switch between threads. Instead, it is better to have a small pool of threads execute your code as work becomes available.

There are times when there is no alternative Thread. If you need to specify the name (for debugging purposes) or the apartment state (to show a UI), you must create your own Thread (note that having multiple UI threads is generally a bad idea). Also, if you want to maintain an object that is owned by a single thread and can only be used by that thread, it is much easier to explicitly create a Thread instance for it so you can easily check whether code trying to use it is running on the correct thread.

**ThreadPool**

ThreadPool is a wrapper around a pool of threads maintained by the CLR. ThreadPool gives you no control at all; you can submit work to execute at some point, and you can control the size of the pool, but you can't set anything else. You can't even tell when the pool will start running the work you submit to it.

Using ThreadPool avoids the overhead of creating too many threads. However, if you submit too many long-running tasks to the threadpool, it can get full, and later work that you submit can end up waiting for the earlier long-running items to finish. In addition, the ThreadPool offers no way to find out when a work item has been completed (unlike Thread.Join()), nor a way to get the result. Therefore, ThreadPool is best used for short operations where the caller does not need the result.

**Task**

Finally, the Task class from the Task Parallel Library offers the best of both worlds. Like the ThreadPool, a task does not create its own OS thread. Instead, tasks are executed by a TaskScheduler; the default scheduler simply runs on the ThreadPool.

Unlike the ThreadPool, Task also allows you to find out when it finishes, and (via the generic Task) to return a result. You can call ContinueWith() on an existing Task to make it run more code once the task finishes (if it's already finished, it will run the callback immediately). If the task is generic, ContinueWith() will pass you the task's result, allowing you to run more code that uses it.

You can also synchronously wait for a task to finish by calling Wait() (or, for a generic task, by getting the Result property). Like Thread.Join(), this will block the calling thread until the task finishes. Synchronously waiting for a task is usually bad idea; it prevents the calling thread from doing any other work, and can also lead to deadlocks if the task ends up waiting (even asynchronously) for the current thread.

Since tasks still run on the ThreadPool, they should not be used for long-running operations, since they can still fill up the thread pool and block new work. Instead, Task provides a LongRunning option, which will tell the TaskScheduler to spin up a new thread rather than running on the ThreadPool.

All newer high-level concurrency APIs, including the Parallel.For*() methods, PLINQ, C# 5 await, and modern async methods in the BCL, are all built on Task.

**Conclusion**

The bottom line is that Task is almost always the best option; it provides a much more powerful API and avoids wasting OS threads.

The only reasons to explicitly create your own Threads in modern code are setting per-thread options, or maintaining a persistent thread that needs to maintain its own identity.

### Before the async and await keywords
https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/tpl-and-traditional-async-programming 

### async and await keywords added in C# 5

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/index

### Exception handling

How exception handling looks without async and await: 

https://jeremybytes.blogspot.com/2015/01/task-and-await-basic-exception-handling.html

if you don't attempt to get the result of a  **Task**  (either by using  **await**  or by getting the  **Result**  directly) then it just sits there, holding on to the exception object, waiting to get GCed. 

#### AggregateExceptions 

The AggregateException class is an exception type, that acts a wrapper for a collection of child exceptions.

await (unlike Task.Wait()) does not wrap a thrown exception in an AggregateException and instead just re-throws the exception thrown within the task. This is excellent when we are dealing with asynchronous code which only has one execution path, and as a result can only throw one exception at a time. However, a Task can be composed of several other tasks running concurrently. Each and every one of these internal tasks can throw an exception, and thus every Task might handle more than one exception (which is one of the reasons for the name AggregateException).

Synchronous code such as Task.Wait() and Task.Result will throw an AggregateException.

When using the await keyword you should be aware that you’ll only catch a single exception out of possibly more than one thrown. If it matters, take action to store the Task instance and access its “Exception” property.
This will contain the AggregateException.

#### "async void" methods can be deadly

https://blogs.msdn.microsoft.com/ptorr/2014/12/10/async-exceptions-in-c/ 
Basically, in order to be safe you need to do one of two things:

1.  Handle exceptions within the  **async**  method itself; or
2.  Return a  **Task<T>**  and ensure that the caller attempts to get the result whilst also handling exceptions (possibly in a parent stack frame)

Failure to do either of these things will result in unwanted behaviour.

Async void methods have different error-handling semantics. When an exception is thrown out of an async Task or async Task method, that exception is captured and placed on the Task object. With async void methods, there is no Task object, so any exceptions thrown out of an async void method will be raised directly on the SynchronizationContext that was active when the async void method started

#### "async void" methods can be necessary

It's perfectly fine to have an  **async void**  method (such as an event handler) so long as you look after exceptions within that method.

Best to use **async void** at the top of your codebase (i.e. event handler). 

### Unobserved Exceptions

In the .NET Framework 4, by default, if a `Task` that has an unobserved exception is garbage collected, the finalizer throws an exception and terminates the process. The termination of the process is determined by the timing of garbage collection and finalization. To make it easier for developers to write asynchronous code based on tasks, the .NET Framework 4.5 changes this default behavior for unobserved exceptions. Unobserved exceptions still cause the `UnobservedTaskException` event to be raised, but by default, the process does not terminate. Instead, the exception is ignored after the event is raised, regardless of whether an event handler observes the exception.

## Multithreading

### Task.Factory.StartNew vs Task.Run

As it is stated  [here](http://blogs.msdn.com/b/pfxteam/archive/2011/10/24/10229468.aspx):

> So, in the .NET Framework 4.5 Developer Preview, we’ve introduced the new Task.Run method.**This in no way obsoletes**  Task.Factory.StartNew,  **but rather should simply be thought of as a quick way to use**  Task.Factory.StartNew  **without needing to specify a bunch of parameters. It’s a shortcut.**  In fact, Task.Run is actually implemented in terms of the same logic used for Task.Factory.StartNew, just passing in some default parameters. When you pass an Action to Task.Run:

```
Task.Run(someAction);
```

> that’s exactly equivalent to:

```
Task.Factory.StartNew(someAction, 
    CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
```

