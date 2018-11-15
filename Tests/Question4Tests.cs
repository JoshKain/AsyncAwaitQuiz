using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question4Tests
    {
        /*
            The answer is A
            
            Test 1
            Test 2
            Test 3

            The code will write Test 1 and Test 2 to the console.
            It will then begin an HTTP request.
            "await" means that execution of the method is paused whilst the network I/O is taking place.
            As "await" is non-blocking, the thread will continue to execute the calling method (Run). 
            As Operation2 doesn't return a task which is being awaited by the Run method, the Run method will continue execution.
            It will then invoke Operation3 which writes Test 3 to the console.
            Execution of Run ends before the HTTP request is completed. 
            As Run is the only method being run by the program, the program terminates before the request is completed, so the thread never re-enters the Operation2 method and never writes Test 2.5 to the console.
        */

        [Test]
        public void Run()
        {
            Question4.Run();
        }
    }
}
