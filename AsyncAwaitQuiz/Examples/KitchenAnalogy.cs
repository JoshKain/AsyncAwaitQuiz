using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitQuiz.Examples.Models;

namespace AsyncAwaitQuiz.Examples
{
    public class KitchenAnalogy
    {
        public static void SingleSynchronousThread()
        {
            BoilingWater boilingWater = BoilWaterAsync().Result;
            CookedPasta cookedPasta = CookPasta(boilingWater);
            DrainedCookedPasta drainedCookedPasta = DrainPasta(cookedPasta);
            TomatoPasta tomatoPasta = AddSauceToPasta(drainedCookedPasta);
            GratedCheese gratedCheese = GrateCheese();
            CheeseAndTomatoPasta cheeseAndTomatoPasta = AddCheeseToPasta(gratedCheese, tomatoPasta);
            PreHeatedOven preHeatedOven = PreHeatOvenAsync().Result;
            FinishedPastaDish finishedPastaDish = BakePastaAsync(cheeseAndTomatoPasta, preHeatedOven).Result;
            Dessert dessert = PrepareDessert();
            EatMeal(finishedPastaDish, dessert);
        }

        public static async Task SingleAsynchronousThread()
        {
            Task<BoilingWater> boilWaterTask = BoilWaterAsync();
            Task<PreHeatedOven> preHeatOvenTask = PreHeatOvenAsync();
            GratedCheese gratedCheese = GrateCheese();
            BoilingWater boilingWater = await boilWaterTask;
            CookedPasta cookedPasta = CookPasta(boilingWater);
            DrainedCookedPasta drainedCookedPasta = DrainPasta(cookedPasta);
            TomatoPasta tomatoPasta = AddSauceToPasta(drainedCookedPasta);
            CheeseAndTomatoPasta cheeseAndTomatoPasta = AddCheeseToPasta(gratedCheese, tomatoPasta);
            PreHeatedOven preHeatedOven = await preHeatOvenTask;
            Task<FinishedPastaDish> bakePastaTask = BakePastaAsync(cheeseAndTomatoPasta, preHeatedOven);
            Dessert dessert = PrepareDessert();
            FinishedPastaDish finishedPastaDish = await bakePastaTask;
            EatMeal(finishedPastaDish, dessert);
        }

        public static void MultipleSynchronousThreads()
        {
            Task<PreHeatedOven> preHeatOvenTask = Task.Run(PreHeatOvenAsync);
            Task<Dessert> prepareDessertTask = Task.Run(() => PrepareDessert());
            Task<GratedCheese> grateCheeseTask = Task.Run(() => GrateCheese());

            BoilingWater boilingWater = BoilWaterAsync().Result;
            CookedPasta cookedPasta = CookPasta(boilingWater);
            DrainedCookedPasta drainedCookedPasta = DrainPasta(cookedPasta);
            TomatoPasta tomatoPasta = AddSauceToPasta(drainedCookedPasta);
            GratedCheese gratedCheese = grateCheeseTask.Result;
            CheeseAndTomatoPasta cheeseAndTomatoPasta = AddCheeseToPasta(gratedCheese, tomatoPasta);
            PreHeatedOven preHeatedOven = preHeatOvenTask.Result;
            FinishedPastaDish finishedPastaDish = BakePastaAsync(cheeseAndTomatoPasta, preHeatedOven).Result;
            Dessert dessert = prepareDessertTask.Result;
            EatMeal(finishedPastaDish, dessert);
        }

        public static async Task MultipleAsynchronousThreads()
        {
            Task<Dessert> prepareDessertTask = Task.Run(() => PrepareDessert());
            Task<GratedCheese> grateCheeseTask = Task.Run(() => GrateCheese());

            Task<BoilingWater> boilWaterTask = BoilWaterAsync(); 
            Task<PreHeatedOven> preHeatOvenTask = PreHeatOvenAsync();
            BoilingWater boilingWater = await boilWaterTask;
            CookedPasta cookedPasta = CookPasta(boilingWater);
            DrainedCookedPasta drainedCookedPasta = DrainPasta(cookedPasta);
            TomatoPasta tomatoPasta = AddSauceToPasta(drainedCookedPasta);
            GratedCheese gratedCheese = await grateCheeseTask;
            CheeseAndTomatoPasta cheeseAndTomatoPasta = AddCheeseToPasta(gratedCheese, tomatoPasta);
            PreHeatedOven preHeatedOven = await preHeatOvenTask;
            FinishedPastaDish finishedPastaDish = await BakePastaAsync(cheeseAndTomatoPasta, preHeatedOven);
            Dessert dessert = await prepareDessertTask;
            EatMeal(finishedPastaDish, dessert);
        }

        private static async Task<BoilingWater> BoilWaterAsync()
        {
            Console.WriteLine("Starting to boil water...");
            await Task.Delay(5000);
            Console.WriteLine("The water has finished boiling.");
            return new BoilingWater();
        }

        private static CookedPasta CookPasta(BoilingWater boilingWater)
        {
            Console.WriteLine("Starting to cook the pasta...");
            Thread.Sleep(5000);
            CookedPasta cookedPasta = new CookedPasta(boilingWater);
            Console.WriteLine("The pasta is now cooked.");
            return cookedPasta;
        }

        private static DrainedCookedPasta DrainPasta(CookedPasta cookedPasta)
        {
            Console.WriteLine("Draining the pasta...");
            Thread.Sleep(1000);
            Console.WriteLine("The pasta is now drained.");
            return new DrainedCookedPasta(cookedPasta);
        }

        private static TomatoPasta AddSauceToPasta(DrainedCookedPasta drainedCookedPasta)
        {
            Console.WriteLine("Adding the sauce to the pasta...");
            Thread.Sleep(1000);
            Console.WriteLine("The sauce has now been added to the pasta.");
            return new TomatoPasta(drainedCookedPasta);
        }

        private static GratedCheese GrateCheese()
        {
            Console.WriteLine("Grating the cheese...");
            Thread.Sleep(2000);
            Console.WriteLine("The cheese is now grated.");
            return new GratedCheese();
        }

        private static CheeseAndTomatoPasta AddCheeseToPasta(GratedCheese gratedCheese, TomatoPasta tomatoPasta)
        {
            Console.WriteLine("Adding cheese to the pasta...");
            Thread.Sleep(1000);
            Console.WriteLine("The cheese has been added to the pasta.");
            return new CheeseAndTomatoPasta(gratedCheese, tomatoPasta);
        }

        private static async Task<PreHeatedOven> PreHeatOvenAsync()
        {
            Console.WriteLine("Switching on the oven...");
            await Task.Delay(15000);
            Console.WriteLine("The oven is now pre-heated.");
            return new PreHeatedOven();
        }

        private static async Task<FinishedPastaDish> BakePastaAsync(CheeseAndTomatoPasta cheeseAndTomatoPasta, PreHeatedOven preHeatedOven)
        {
            Console.WriteLine("Placed the pasta dish in the oven. Baking has begun...");
            await Task.Delay(15000);
            Console.WriteLine("The pasta dish has now finished baking. The cheese is all lovely and golden!");
            return new FinishedPastaDish(cheeseAndTomatoPasta, preHeatedOven); 
        }

        private static Dessert PrepareDessert()
        {
            Console.WriteLine("Starting to prepare the dessert...");
            Thread.Sleep(20000);
            Console.WriteLine("Finished making the dessert! It looks delicious!");
            return new Dessert();
        }

        private static void EatMeal(FinishedPastaDish finishedPastaDish, Dessert dessert)
        {
            Console.WriteLine("The pasta dish and dessert are both completed. Time to eat!");
        }
    }
}
