using System.Threading.Tasks;
using AsyncAwaitQuiz.await_best_practices;
using NUnit.Framework;

namespace Tests.Best_practices
{
    public class RedundantAsyncKeywordTests
    {
        [Test]
        public static async Task Test_OperationAsync()
        {
            await new RedundantAsyncKeyword().OperationAsync(); 
        }

        [Test]
        public static async Task Test_OperationWithNoAwaitAsync()
        {
            await new RedundantAsyncKeyword().OperationWithNoAwaitAsync();
        }
    }
}
