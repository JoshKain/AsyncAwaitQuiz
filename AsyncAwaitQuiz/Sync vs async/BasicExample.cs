using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Sync_vs_async
{
    public class BasicExample
    {
        public void Operation()
        {
            DoSomeStuffAsync().Wait();
        }

        public async Task OperationAsync()
        {
            await DoSomeStuffAsync();
        }
        private Task DoSomeStuffAsync()
        {
            Console.WriteLine("Starting async stuff...");
            // Simulating a 5-second async operation
            return Task.Delay(5000);
        }
    }
}
