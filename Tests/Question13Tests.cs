using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question13Tests
    {
        [Test]
        public async Task Run()
        {
            await Question13.RunAsync();
        }
    }
}
