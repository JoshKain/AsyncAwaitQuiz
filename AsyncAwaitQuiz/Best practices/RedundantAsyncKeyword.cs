using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.await_best_practices
{
    // Here is an example showing the same method, one with "async" and "await" keywords, and one without.
    // The one without is more efficient as less code is ran under the hood, so it's best to not 
    // have redundant async and await keywords. 
    // However, the thing to remember is that this means any exceptions will be bubbled up
    // to the calling method, whereas using await will throw the exception at that point.
    public class RedundantAsyncKeyword
    {
        public async Task OperationAsync()
        {
            await DoSomeStuffAsync();
        }

        public Task OperationWithNoAwaitAsync()
        {
            return DoSomeStuffAsync();
        }

        private async Task DoSomeStuffAsync()
        {
            Console.WriteLine("Starting asynchronous operation...");
            // Simulating an asynchronous operation which takes 5 seconds
            await Task.Delay(5000);
            Console.WriteLine("Finished asynchronous operation.");
        }
    }
}
