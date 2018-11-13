using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question3
    {
        public static void Run()
        {
            Operation1();
            Operation2();
            Operation3();
        }

        private static void Operation1()
        {
            Console.WriteLine("Test 1");
        }

        private static void Operation2()
        {
            Console.WriteLine("Test 2");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(new Uri("https://www.google.com")).Result;
            Console.WriteLine("Test 2.5");
        }

        private static void Operation3()
        {
            Console.WriteLine("Test 3");
        }
    }
}
