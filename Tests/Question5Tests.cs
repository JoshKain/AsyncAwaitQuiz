using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question5Tests
    {
        /*
            The answer is E (None of the above)
            
            Test 1
            Test 2
            Test 3
            Test 2.5

            The code will invoke Operation1 which writes "Test 1" to the console.
            The thread will then sleep for 5 seconds, before invoking Operation2 which writes "Test 2" to the console and begins an HTTP request.
            "await" means that execution of the method is paused whilst the network I/O is taking place.
            As "await" is non-blocking, the thread will continue to execute the calling method (Run). 
            As Operation2 doesn't return a task which is being awaited by the Run method, the Run method will continue execution.
            It will then invoke Operation3 which writes Test 3 to the console.
            The thread then waits for 5 seconds. This provides enough time for the HTTP request to be completed.
            The thread resumes execution of Operation2 and writes Test 2.5 to the console.
        */

        [Test]
        public void Run()
        {
            Question5.Run();
        }
    }
}
