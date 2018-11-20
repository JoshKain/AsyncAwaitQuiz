using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question13
    {
        /*
           Which of these methods has the fastest performance? Method1Async or Method2Async?
           NOTE: You can assume the task returned by each method is awaited by the calling method.

           A). Method1Async

           B). Method2Async

           C). They both have similar performance
       */

        public static async Task Method1()
        {
            Task operation1Task = Operation1Async();
            Task operation2Task = Operation2Async();
            Task operation3Task = Operation3Async();
            await operation1Task;
            await operation2Task;
            await operation3Task;
        }

        public static async Task Method2Async()
        {
            Task operation1Task = Task.Run(Operation1Async);
            Task operation2Task = Task.Run(Operation2Async);
            Task operation3Task = Task.Run(Operation3Async);
            await operation1Task;
            await operation2Task;
            await operation3Task;
        }

        private static async Task Operation1Async()
        {
            Console.WriteLine("Test 1");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com"));
            Console.WriteLine("Test 1.5");
        }

        private static async Task Operation2Async()
        {
            Console.WriteLine("Test 2");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com"));
            Console.WriteLine("Test 2.5");
        }

        private static async Task Operation3Async()
        {
            Console.WriteLine("Test 3");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com"));
            Console.WriteLine("Test 3.5");
        }
    }
}
