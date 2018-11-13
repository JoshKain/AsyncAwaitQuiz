using System;

namespace AsyncAwaitQuiz
{
    public static class Question1
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
        }

        private static void Operation3()
        {
            Console.WriteLine("Test 3");
        }
    }
}
