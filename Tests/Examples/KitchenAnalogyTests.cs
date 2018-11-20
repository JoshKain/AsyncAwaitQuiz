using System.Threading.Tasks;
using AsyncAwaitQuiz.Examples;
using NUnit.Framework;

namespace Tests.Examples
{
    public class KitchenAnalogyTests
    {
        [Test]
        public static void Test_SingleSynchronousThread()
        {
            KitchenAnalogy.SingleSynchronousThread();
        }

        [Test]
        public static async Task Test_SingleAsynchronousThread()
        {
            await KitchenAnalogy.SingleAsynchronousThread();
        }
        
        [Test]
        public static void Test_MultipleSynchronousThreads()
        {
            KitchenAnalogy.MultipleSynchronousThreads();
        }

        [Test]
        public static async Task Test_MultipleAsynchronousThreads()
        {
            await KitchenAnalogy.MultipleAsynchronousThreads();
        }

    }
}
