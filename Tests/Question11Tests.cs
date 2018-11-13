using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question11Tests
    {
        [Test]
        public async Task Run()
        {
            await Question11.RunAsync();
        }
    }
}
