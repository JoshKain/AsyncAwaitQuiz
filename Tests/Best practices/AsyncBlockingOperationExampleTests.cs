using System.Threading.Tasks;
using AsyncAwaitQuiz.Best_practices;
using AsyncAwaitQuiz.Examples;
using NUnit.Framework;

namespace Tests.Best_practices
{
    public class BlockingOperationsTests
    {
        [Test]
        public static async Task Test_Operation1Async()
        {
            await new AsyncBlockingOperationExample().Operation1Async();
        }

        [Test]
        public static async Task Test_Operation2Async()
        {
            await new AsyncBlockingOperationExample().Operation2Async();
        }

        [Test]
        public static async Task Test_Operation3Async()
        {
            await new AsyncBlockingOperationExample().Operation3Async();
        }
    }
}
