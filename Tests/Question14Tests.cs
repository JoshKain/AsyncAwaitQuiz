using System.Threading.Tasks;
using AsyncAwaitQuiz;
using NUnit.Framework;

namespace Tests
{
    public class Question14Tests
    {
        [Test]
        public async Task Run()
        {
            await Question14.RunAsync();
        }
    }
}
