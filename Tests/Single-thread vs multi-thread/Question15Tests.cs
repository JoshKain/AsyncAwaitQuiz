using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question15Tests
    {
        /*
            The answer is C
        */

        [Test]
        public async Task Run()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            await Question15.Method1();
            long method1Result = stopwatch1.ElapsedMilliseconds;

            stopwatch2.Start();
            await Question15.Method2Async();
            long method2Result = stopwatch2.ElapsedMilliseconds;
            Console.WriteLine($"The difference in time between the two methods is {method1Result - method2Result}ms");
        }
    }
}
