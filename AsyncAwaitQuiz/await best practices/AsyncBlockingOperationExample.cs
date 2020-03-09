using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Examples
{
    // In this example we show methods which do some IO stuff and CPU stuff.
    // Operation1Async is bad as it does waits for all the I/O stuff, then does all the CPU stuff. 
    // Operation2Async is bad as it the CPU stuff, then waits for all the I/O stuff.
    // Operation3Async is good as it starts the I/O stuff, then does all the CPU stuff, then waits 
    // for the remainder of the I/O stuff to be completed.
    public class AsyncBlockingOperationExample
    {

        public async Task Operation1Async()
        {
            await DoSomeIoStuffAsync();
            DoSomeCpuStuff();
        }
        public async Task Operation2Async()
        {
            DoSomeCpuStuff();
            await DoSomeIoStuffAsync();
        }
        public async Task Operation3Async()
        {
            var ioStuffTask = DoSomeIoStuffAsync(); 
            DoSomeCpuStuff();
            await ioStuffTask;
        }

        private void DoSomeCpuStuff()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine($"Doing a thing with number {i}");
            }
        }
        private Task DoSomeIoStuffAsync()
        {
            HttpClient httpClient = new HttpClient();
            return httpClient.GetAsync(
                new Uri("http://www.deelay.me/5000/http://www.bbc.com"));
        }
    }
}
