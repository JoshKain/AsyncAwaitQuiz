using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question10Tests
    {
        [Test]
        public async Task Run()
        {
            await Question10.RunAsync();
        }
    }
}
