using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question13
    {
        public static async Task RunAsync()
        {
            Task operation1Task = Operation1Async();
            Task operation2Task = Operation2Async();
            Task operation3Task = Operation3Async();
            await operation1Task;
            await operation2Task;
            await operation3Task;
        }

        private static async Task Operation1Async()
        {
            Console.WriteLine("Test 1");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("https://www.bbc.com"));
            Console.WriteLine("Test 1.5");
        }

        private static async Task Operation2Async()
        {
            Console.WriteLine("Test 2");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("https://www.google.com"));
            Console.WriteLine("Test 2.5");
        }

        private static async Task Operation3Async()
        {
            Console.WriteLine("Test 3");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("https://www.facebook.com"));
            Console.WriteLine("Test 3.5");
        }
    }
}
