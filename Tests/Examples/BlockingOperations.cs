using System.Threading.Tasks;
using AsyncAwaitQuiz.Examples;
using NUnit.Framework;

namespace Tests.Examples
{
    public class BlockingOperationsTests
    {
        [Test]
        public static void Test_Operation()
        {
            new BlockingOperations().Operation();
        }

        [Test]
        public static async Task Test_OperationAsync()
        {
            await new BlockingOperations().OperationAsync();
        }
    }
}
