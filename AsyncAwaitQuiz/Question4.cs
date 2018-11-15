using System;
using System.Net.Http;

namespace AsyncAwaitQuiz
{
    public static class Question4
    {
        /*
            What will be the output of the Run method? 

            A). Test 1
                Test 2
                Test 3

            B). Test 1
                Test 2

            C). Test 1
                Test 3
            
            D). Test 1
                Test 2
                Test 2.5
                Test 3

            E). None of the above.
        */

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

        private static async void Operation2()
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
