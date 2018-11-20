using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwaitQuiz;
using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    public class Question10Tests
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
            await Question10.Method1Async();
            long method1Result = stopwatch1.ElapsedMilliseconds;

            stopwatch2.Start();
            await Question10.Method2Async();
            long method2Result = stopwatch2.ElapsedMilliseconds;
            Console.WriteLine($"Method2Async is {method1Result - method2Result}ms faster than Method1Async");
        }
    }
}
