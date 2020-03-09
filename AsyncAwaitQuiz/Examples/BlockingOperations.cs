using System;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Examples
{
    public class BlockingOperations
    {
        public void Operation()
        {
            DoSomeStuffAsync().Wait();
        }

        public async Task OperationAsync()
        {
            await DoSomeStuffAsync();
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
