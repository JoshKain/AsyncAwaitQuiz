using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question11Tests
    {
        /*
            The answer is A 
        */

        [Test]
        public async Task Run()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            await Question11.Method1Async();
            long method1Result = stopwatch1.ElapsedMilliseconds;

            stopwatch2.Start();
            await Question11.Method2Async();
            long method2Result = stopwatch2.ElapsedMilliseconds;
            Console.WriteLine($"Method1Async is {method2Result - method1Result}ms faster than Method2Async");
        }
    }
}
