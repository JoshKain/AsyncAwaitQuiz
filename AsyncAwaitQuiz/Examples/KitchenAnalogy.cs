using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Examples
{
    public class KitchenAnalogy
    {
        public static void SingleSynchronousThread()
        {
            BoilWaterAsync().Wait();
            CookPasta();
            DrainPasta();
            GrateCheese();
            AddCheeseToPasta();
            PreHeatOvenAsync().Wait();
            BakePastaAsync().Wait();
            PrepareDessert();
        }

        public static async Task SingleAsynchronousThread()
        {
            Task boilWaterTask = BoilWaterAsync();
            Task preHeatOvenTask = PreHeatOvenAsync();
            GrateCheese();
            await boilWaterTask;
            CookPasta();
            DrainPasta();
            AddCheeseToPasta();
            await preHeatOvenTask;
            Task bakePastaTask = BakePastaAsync();
            PrepareDessert();
            await bakePastaTask;
        }

        public static void MultipleSynchronousThreads()
        {
            Task preHeatOvenTask = Task.Run(PreHeatOvenAsync);
            Task prepareDessertTask = Task.Run(() => PrepareDessert());
            Task grateCheeseTask = Task.Run(() => GrateCheese()); 

            BoilWaterAsync().Wait();
            CookPasta();
            DrainPasta();
            grateCheeseTask.Wait();
            AddCheeseToPasta();
            preHeatOvenTask.Wait();
            BakePastaAsync().Wait();
            prepareDessertTask.Wait();
        }

        public static async Task MultipleAsynchronousThreads()
        {
            Task prepareDessertTask = Task.Run(() => PrepareDessert());
            Task grateCheeseTask = Task.Run(() => GrateCheese());

            Task boilWaterTask = BoilWaterAsync(); 
            Task preHeatOvenTask = PreHeatOvenAsync();
            await boilWaterTask;
            CookPasta();
            DrainPasta();
            await grateCheeseTask;
            AddCheeseToPasta();
            await preHeatOvenTask;
            await BakePastaAsync();
            await prepareDessertTask;
        }

        private static async Task BoilWaterAsync()
        {
            Console.WriteLine("Starting to boil water...");
            await Task.Delay(5000);
            Console.WriteLine("The water has finished boiling.");
        }

        private static void CookPasta()
        {
            Console.WriteLine("Starting to cook the pasta...");
            Thread.Sleep(5000);
            Console.WriteLine("The pasta is now cooked.");
        }

        private static void DrainPasta()
        {
            Console.WriteLine("Draining the pasta...");
            Thread.Sleep(1000);
            Console.WriteLine("The pasta is now drained.");
        }

        private static void GrateCheese()
        {
            Console.WriteLine("Grating the cheese...");
            Thread.Sleep(2000);
            Console.WriteLine("The cheese is now grated.");
        }

        private static void AddCheeseToPasta()
        {
            Console.WriteLine("Adding cheese to the pasta...");
            Thread.Sleep(1000);
            Console.WriteLine("The cheese has been added to the pasta.");
        }

        private static async Task PreHeatOvenAsync()
        {
            Console.WriteLine("Switching on the oven...");
            await Task.Delay(15000);
            Console.WriteLine("The oven is now pre-heated.");
        }

        private static async Task BakePastaAsync()
        {
            Console.WriteLine("Placed the pasta dish in the oven. Baking has begun...");
            await Task.Delay(15000);
            Console.WriteLine("The pasta dish has now finished baking. The cheese is all lovely and golden!");
        }

        private static void PrepareDessert()
        {
            Console.WriteLine("Starting to prepare the dessert...");
            Thread.Sleep(20000);
            Console.WriteLine("Finished making the dessert! Delicious!");
        }
    }
}
