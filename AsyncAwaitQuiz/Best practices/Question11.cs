using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question11
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
            Task task1 = GetWebpageAsync();
            Task task2 = GetWebpageAsync();
            Task task3 = GetWebpageAsync();
            await task1;
            await task2;
            await task3;
        }
        public static async Task Method2Async()
        {
            await GetWebpageAsync();
            await GetWebpageAsync();
            await GetWebpageAsync();
        }
        private static Task GetWebpageAsync()
        {
            HttpClient httpClient = new HttpClient();
            return httpClient
                .GetAsync(new Uri("http://www.deelay.me/5000/https://www.bbc.com"));
        }
    }
}
