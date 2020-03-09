using System.Threading.Tasks;
using AsyncAwaitQuiz.Examples;
using NUnit.Framework;

namespace Tests.Examples
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
