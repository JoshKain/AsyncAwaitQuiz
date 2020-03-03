using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AsyncAwaitQuiz.Examples
{
    public class SynchronousOperations
    {
        public void DoLotsOfWork()
        {
            for (int i = 0; i < 1000000; i++)
            {
                DoAThing(i);
            }
        }

        public void DoAThing(int number)
        {
            // Some sort of work here
            Console.WriteLine($"Doing a thing with number {number}");
        }

        public int SynchronousCalculation()
        {
            int resultA = A();
            int resultB = B();
            int resultC = C();
            int resultD = D();
            return resultA + resultB + resultC + resultD;
        }

        public void DoLongRunningStuff()
        {
            // Simulating a synchronous operation which takes a long time
            Thread.Sleep(TimeSpan.FromMinutes(1));
        }

        private static int A()
        {
            return 1;
        }

        private static int B()
        {
            return 2;
        }

        private static int C()
        {
            return 3;
        }

        private static int D()
        {
            return 4;
        }
    }
}
