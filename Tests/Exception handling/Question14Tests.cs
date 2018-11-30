using System.Threading.Tasks;
using AsyncAwaitQuiz.Sync_vs_async;
using NUnit.Framework;

namespace Tests.Sync_vs_async
{
    //[Ignore("Question not ready to be asked yet.")]
    public class Question14Tests
    {
        /*
            The answer is A

            AggregateException
            One or more errors occurred. (This is a test exception)
        */
        [Test]
        public void PartA()
        {
            Question14.PartA();
        }

        /*
            The answer is A

            AggregateException
            One or more errors occurred. (This is a test exception)
        */
        [Test]
        public void PartB()
        {
            Question14.PartB();
        }

        /*
            The answer is B

            Exception
            This is a test exception
        */
        [Test]
        public void PartC()
        {
            Question14.PartC();
        }

        /*
            The answer is B

            Exception
            This is a test exception
        */
        [Test]
        public async Task PartD()
        {
            await Question14.PartD();
        }

        /*
            The answer is B

            Exception
            This is a test exception
        */
        [Test]
        public async Task PartE()
        {
            await Question14.PartE();
        }


        /*
            The answer is D

            It will completely terminate the process. It won't throw a visible exception
            and will completely kill the application/debugger.

        */
        [Test]
        public void PartF()
        {
            Question14.PartF();
        }

        /*
            The answer is C

            It will throw the following uncaught exception:

            Exception
            This is a test exception
        */
        [Test]
        public async Task PartG()
        {
            await Question14.PartG();
        }

        /*
            The answer is A

            AggregateException
            One or more errors occurred. (This is a test exception)
        */
        [Test]
        public void PartH()
        {
            Question14.PartH();
        }

        /*
            The answer is D

            There is no output as the exception of the task is never checked.
        */
        [Test]
        public void PartI()
        {
            Question14.PartI();
        }

    }
}
