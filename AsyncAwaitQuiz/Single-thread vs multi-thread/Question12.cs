using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question12
    {
        /*
           Which of these methods has the fastest performance? Method1Async or Method2Async?
           NOTE: You can assume the task returned by each method is awaited by the calling method.

           A). Method1Async

           B). Method2Async

           C). They both have similar performance
       */

        public static void Method1()
        {
            Operation1();
            Operation2();
            Operation3();
        }

        public static async Task Method2Async()
        {
            Task operation1ThreadTask = Task.Run(() => Operation1());
            Task operation2ThreadTask = Task.Run(() => Operation2());
            Task operation3ThreadTask = Task.Run(() => Operation3());
            await operation1ThreadTask;
            await operation2ThreadTask;
            await operation3ThreadTask;
        }

        private static void Operation1()
        {
            Console.WriteLine("Test 1");
            Thread.Sleep(5000);
            Console.WriteLine("Test 1.5");
        }

        private static void Operation2()
        {
            Console.WriteLine("Test 2");
            Thread.Sleep(5000);
            Console.WriteLine("Test 2.5");
        }

        private static void Operation3()
        {
            Console.WriteLine("Test 3");
            Thread.Sleep(5000);
            Console.WriteLine("Test 3.5");
        }
    }
}
