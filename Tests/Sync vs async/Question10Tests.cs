using System.Threading.Tasks;
using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    public class Question10Tests
    {
        /*
            The answer is C
            
            Test 1
            Test 1.5
            Test 2
            Test 3
            Test 2.5

            The code will invoke Operation1Async which writes "Test 1" to the console.
            It then waits 5 seconds, writes "Test 1.5" to the console and then returns a completed task to the calling method.

            The calling method (RunAsync) awaits the task. The task is already completed, so it can immediately continue execution.

            Operation2Async is then invoked, which writes "Test 2" to the console and begins an HTTP request.
            "await" means that execution of the method is paused whilst the network I/O is taking place.

            As "await" is non-blocking, the thread will continue to execute the calling method (RunAsync). 
            Operation2Async returns an incomplete task to RunAsync and allows the thread to continue execution until Operation2 is complete.

            Operation3 is then invoked, writing "Test 3" to the console. 

            The task returned from RunAsync is being awaited, allowing the thread to continue execution in the calling method (the unit test) until RunAsync is complete.
            Execution therefore waits for the HTTP request to complete. 
            Once the HTTP request is complete, execution in Operation2Async continues, so "Test 2.5" is written to the console and control is passed back to RunAsync and execution continues.
            RunAsync is now complete, so control is passed back to the unit test method which was awaiting its completion.
        */


        [Test]
        public async Task Run()
        {
            await Question10.RunAsync();
        }
    }
}
