using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Sync_vs_async
{
    public static class Question10
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
            Task operation1ResultTask1 = Operation1ResultAsync();
            Task operation1ResultTask2 = Operation1ResultAsync();
            Task operation1ResultTask3 = Operation1ResultAsync();
            await operation1ResultTask1;
            await operation1ResultTask2;
            await operation1ResultTask3;
        }
        public static async Task Method2Async()
        {
            Task operation1AwaitTask1 = Operation1AwaitAsync();
            Task operation1AwaitTask2 = Operation1AwaitAsync();
            Task operation1AwaitTask3 = Operation1AwaitAsync();
            await operation1AwaitTask1;
            await operation1AwaitTask2;
            await operation1AwaitTask3;
        }
        private static async Task Operation1AwaitAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient
                .GetAsync(new Uri("http://www.deelay.me/5000/http://www.bbc.com"));
        }
        private static Task Operation1ResultAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = httpClient
                .GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com")).Result;
            return Task.CompletedTask;
        }
    }
}
