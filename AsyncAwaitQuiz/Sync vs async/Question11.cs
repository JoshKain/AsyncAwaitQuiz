using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Sync_vs_async
{
    public static class Question11
    {
        /*
           What will be the output of the RunAsync method? 
           NOTE: You can assume the task returned by this method is awaited by the calling method.

           A). Test 2
               Test 3
               Test 2.5
               Test 1
               Test 1.5

           B). Test 2
               Test 2.5
               Test 3
               Test 1
               Test 1.5

           C). Test 1
               Test 1.5
               Test 2
               Test 3
               Test 2.5

           D). Test 1
               Test 1.5
               Test 2
               Test 2.5
               Test 3

           E). None of the above.
       */

        public static async Task RunAsync()
        {
            Task operation1Task = Operation1Async();
            await Operation2Async();
            Operation3();
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
