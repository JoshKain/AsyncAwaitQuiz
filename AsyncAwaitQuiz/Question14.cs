using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz
{
    public static class Question14
    {
        public static async Task RunAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Operation1();
            Operation2();
            Operation3();
            long singleThreadResult = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            stopwatch.Start();
            Task operation1ThreadTask = Task.Run(() => Operation1());
            Task operation2ThreadTask = Task.Run(() => Operation2());
            Task operation3ThreadTask = Task.Run(() => Operation3());
            await operation1ThreadTask;
            await operation2ThreadTask;
            await operation3ThreadTask;
            long multiThreadResult = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"The difference in time with multiple threads is {singleThreadResult - multiThreadResult}ms");
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
