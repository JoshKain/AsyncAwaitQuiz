using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    public class Question5Tests
    {
        /*
            The answer is D 
            
            Test 1
            Test 2
            Test 2.5
            Test 3

            The code will invoke Operation1 which writes "Test 1" to the console.
            The thread will then sleep for 5 seconds, before invoking Operation2 which writes "Test 2" to the console and begins an HTTP request.
            "await" means that execution of the method is paused whilst the network I/O is taking place.
            As "await" is non-blocking, the thread will continue to execute the calling method (Run). 
            Operation2 returns an incomplete task and Run is called Wait on that task, meaning it will wait until the task has run to completion. This is a blocking operation, so the thread will do no other work whilst waiting.
            The HTTP request is completed and then "Test 2.5" is written to the console. The task is now complete and Run can continue execution.
            The thread will then invoke Operation3 which writes "Test 3" to the console.
        */

        [Test]
        public void Run()
        {
            Question5.Run();
        }
    }
}
