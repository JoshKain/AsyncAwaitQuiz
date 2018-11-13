using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question12Tests
    {
        [Test]
        public async Task Run()
        {
            await Question12.RunAsync();
        }
    }
}
