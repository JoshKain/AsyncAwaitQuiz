using System.Threading.Tasks;
using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    public class BasicExampleTests
    {
        [Test]
        public void Run()
        {
            new BasicExample().Operation();
        }

        [Test]
        public async Task RunAsync()
        {
            await new BasicExample().OperationAsync();
        }
    }
}
