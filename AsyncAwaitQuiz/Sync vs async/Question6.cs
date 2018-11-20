using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Sync_vs_async
{
    public static class Question6
    {
        /*
           What will be the output of the Run method? 

           A). Test 1
               Test 1.5

           B). Test 1
               Test 1.5
               Test 2

           C). Test 1
               Test 1.5
               Test 2
               Test 3

           D). Test 1
               Test 1.5
               Test 2
               Test 2.5
               Test 3

           E). None of the above.
       */

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
