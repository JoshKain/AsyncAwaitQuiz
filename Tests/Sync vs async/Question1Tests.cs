using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    public class Question1Tests
    {
        /*
            The answer is A
            
            Test 1
            Test 2
            Test 2.5
            Test 3

            The code will write Test 1 and Test 2 to the console.
            It will then begin an HTTP request and wait for it to complete. 
            It will then write Test 2.5 and Test 3 to the console.
        */


        [Test]
        public void Run()
        {
            Question1.Run();
        }
    }
}
