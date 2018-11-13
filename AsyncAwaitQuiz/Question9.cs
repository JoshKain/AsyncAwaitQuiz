using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question9
    {
        public static async void Run()
        {
            await Operation1Async();
            await Operation2Async();
            Operation3();
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
