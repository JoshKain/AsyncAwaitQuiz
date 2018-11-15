using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question16Tests
    {
        [Test]
        public async Task Run()
        {
            await Question16.RunAsync();
        }
    }
}
