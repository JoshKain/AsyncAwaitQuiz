using System.Threading.Tasks;
using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    public class Question9Tests
    {
        /*
            The answer is A

            AggregateException
            One or more errors occurred. (This is a test exception)
        */
        [Test]
        public void PartA()
        {
            Question9.PartA();
        }

        /*
            The answer is A

            AggregateException
            One or more errors occurred. (This is a test exception)
        */
        [Test]
        public void PartB()
        {
            Question9.PartB();
        }

        /*
            The answer is B

            Exception
            This is a test exception
        */
        [Test]
        public void PartC()
        {
            Question9.PartC();
        }

        /*
            The answer is B

            Exception
            This is a test exception
        */
        [Test]
        public async Task PartD()
        {
            await Question9.PartD();
        }

        /*
            The answer is B

            Exception
            This is a test exception
        */
        [Test]
        public async Task PartE()
        {
            await Question9.PartE();
        }
    }
}
