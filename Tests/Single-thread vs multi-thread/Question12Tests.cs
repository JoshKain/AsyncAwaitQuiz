using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question12Tests
    {
        /*
            The answer is B
        */

        [Test]
        public async Task Run()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            Question12.Method1();
            long method1Result = stopwatch1.ElapsedMilliseconds;

            stopwatch2.Start();
            await Question12.Method2Async();
            long method2Result = stopwatch2.ElapsedMilliseconds;
            Console.WriteLine($"Method2Async is {method1Result - method2Result}ms faster than Method1Async");
        }
    }
}
