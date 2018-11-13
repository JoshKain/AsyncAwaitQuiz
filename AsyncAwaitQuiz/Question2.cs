using System;
using System.Threading;

namespace AsyncAwaitQuiz
{
    public static class Question2
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
            Thread.Sleep(5000);
            Console.WriteLine("Test 2.5");
        }

        private static void Operation3()
        {
            Console.WriteLine("Test 3");
        }
    }
}
