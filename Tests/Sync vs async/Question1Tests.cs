using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    
    public class Question1Tests
    {
        /*
            The answer is B
            
            Test 1
            Test 2
            Test 2.5
            Test 3

            The code will write Test 1 and Test 2 to the console, wait 5 seconds, then output Test 2.5 and Test 3 to the console.
        */

        [Test]
        public void Run()
        {
            Question1.Run();
        }
    }
}
