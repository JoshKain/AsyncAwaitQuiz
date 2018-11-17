using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question16
    {
        public static async Task RunAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task operation1AwaitTask1 = Operation1AwaitAsync();
            Task operation1AwaitTask2 = Operation1AwaitAsync();
            Task operation1AwaitTask3 = Operation1AwaitAsync();
            await operation1AwaitTask1;
            await operation1AwaitTask2;
            await operation1AwaitTask3;
            long awaitTime = stopwatch.ElapsedMilliseconds; 
            stopwatch.Reset();

            stopwatch.Start();
            Task operation1ResultTask1 = Operation1ResultAsync();
            Task operation1ResultTask2 = Operation1ResultAsync();
            Task operation1ResultTask3 = Operation1ResultAsync();
            await operation1ResultTask1;
            await operation1ResultTask2;
            await operation1ResultTask3;
            long resultTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"The difference in time with await is {resultTime - awaitTime}ms");
        }

        private static async Task Operation1AwaitAsync()
        {
            Console.WriteLine("Test 1");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("http://www.deelay.me/5000/http://www.bbc.com"));
            Console.WriteLine("Test 1.5");
        }

        private static Task Operation1ResultAsync()
        {
            Console.WriteLine("Test 1");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com")).Result;
            Console.WriteLine("Test 1.5");
            return Task.CompletedTask;
        }
    }
}
