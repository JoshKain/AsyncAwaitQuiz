using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question15Tests
    {
        [Test]
        public async Task Run()
        {
            await Question15.RunAsync();
        }
    }
}
