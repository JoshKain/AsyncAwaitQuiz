using AsyncAwaitQuiz.Examples;
using NUnit.Framework;

namespace Tests.Examples
{
    public class SynchronousOperationsTests
    {
        [Test]
        public static void Test_SynchronousCalculation()
        {
            new SynchronousOperations().SynchronousCalculation();
        }

        [Test]
        public static void Test_DoLotsOfWork()
        {
            new SynchronousOperations().DoLotsOfWork();
        }

        [Test]
        public static void Test_DoLongRunningStuff()
        {
            new SynchronousOperations().DoLongRunningStuff();
        }
    }
}
