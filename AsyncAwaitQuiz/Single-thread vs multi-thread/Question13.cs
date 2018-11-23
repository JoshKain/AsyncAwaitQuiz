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

        public static async Task Method1Async()
        {
            Task task1 = Operation1Async();
            Task task2 = Operation1Async();
            Task task3 = Operation1Async();
            await task1;
            await task2;
            await task3;
        }
        public static async Task Method2Async()
        {
            Task task1 = Task.Run(Operation1Async);
            Task task2 = Task.Run(Operation1Async);
            Task task3 = Task.Run(Operation1Async);
            await task1;
            await task2;
            await task3;
        }
        private static async Task Operation1Async()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient
                .GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com"));
        }
    }
}
