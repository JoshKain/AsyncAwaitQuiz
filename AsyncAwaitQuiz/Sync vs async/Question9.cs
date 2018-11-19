using System;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Sync_vs_async
{
    public static class Question9
    {
        /*
           What will be the output of each of these methods? 
           NOTE: You can assume the task returned by this method is awaited by the calling method.

           A).  AggregateException
                One or more errors occurred. (This is a test exception)

           B).  Exception
                This is a test exception

           C). An uncaught exception is thrown and can be caught in the calling method

           D). None of the above.
       */


        public static void PartA()
        {
            try
            {
                Operation1Async().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }

        public static void PartB()
        {
            try
            {
                Task.Run(async () =>
                {
                    await Operation1Async();
                }).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }

        public static void PartC()
        {
            try
            {
                Operation1Async().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task PartD()
        {
            try
            {
                await Task.Run(Operation1Async);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task PartE()
        {
            try
            {
                await Operation1Async();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }

        public static async void PartF()
        {
            await Operation1Async();
        }

        public static async Task PartG()
        {
            await Operation1Async();
        }

        public static async void PartH()
        {
            try
            {
                Task operation1Task = Operation1Async(); 
                try
                {
                    await Operation1Async();
                }
                catch
                {
                    throw operation1Task.Exception;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }


        public static void PartI()
        {
            Task operation1Task = Operation1Async();
        }

        private static async Task Operation1Async()
        {
            await Operation2Async();
        }

        private static Task Operation2Async()
        {
            throw new Exception("This is a test exception");
        }

    }
}
