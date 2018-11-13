using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question11
    {
        public static async Task RunAsync()
        {
            Task operation1Task = Operation1Async();
            Task operation2Task = Operation2Async();
            Operation3();
            await operation2Task;
            await operation1Task;
        }

        private static Task Operation1Async()
        {
            Console.WriteLine("Test 1");
            Thread.Sleep(5000);
            Console.WriteLine("Test 1.5");
            return Task.CompletedTask;
        }

        private static async Task Operation2Async()
        {
            Console.WriteLine("Test 2");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("https://www.google.com"));
            Console.WriteLine("Test 2.5");
        }

        private static void Operation3()
        {
            Console.WriteLine("Test 3");
        }
    }
}
