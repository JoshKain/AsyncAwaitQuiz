using System;

namespace AsyncAwaitQuiz
{
    public static class Question1
    {
        /*
            What will be the output of the Run method? 

            A). Test 1
                Test 2
                Test 3

            B). Test 3
                Test 2
                Test 1

            C). Your computer explodes violently, killing you and anyone else around you.
            
            D). None of the above. 
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
