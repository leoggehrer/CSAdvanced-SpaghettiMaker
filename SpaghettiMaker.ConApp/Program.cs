using SpaghettiMaker.Common.Dishes;
using SpaghettiMaker.Logic;
using System.Diagnostics;

namespace SpaghettiMaker.ConApp
{
    public class Program
    {
        public static void Main()
        {
            var watch = new Stopwatch();
            watch.Start();
            PrepareFoodAsync();
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Preparation took {watch.ElapsedMilliseconds / 1000} seconds");
        }

        private static void PrepareFoodAsync()
        {
            Task.Run(async () =>
            {
                var tasks = new List<Task>();
                tasks.Add(SpaghettiMakerAsync.PourRedWineAsync());

                //Heat pots
                var potTasks = new Task<Pot>[]
                {
                SpaghettiMakerAsync.HeatPotAsync(),
                SpaghettiMakerAsync.HeatPotAsync(),
                SpaghettiMakerAsync.HeatPotAsync(),
                };

                //Wait for and save pots, because cooking depends on them
                await Task.WhenAll(potTasks);
                var pot1 = potTasks[0].Result;
                var pot2 = potTasks[1].Result;
                var pot3 = potTasks[2].Result;

                //Start cooking
                tasks.Add(CookSpaghettiAndSouce(pot1, pot2, pot3));

                //Toast 2 breads
                tasks.Add(SpaghettiMakerAsync.ToastBreadAsync(2));

                //Pour Water
                tasks.Add(SpaghettiMakerAsync.PourWaterAsync());

                //Wait for all tasks to finish
                await Task.WhenAll(tasks);
            }).Wait();
        }

        private static Task CookSpaghettiAndSouce(Pot pot1, Pot pot2, Pot pot3)
        {
            return Task.Run(async () =>
            {
                var cookingTasks = new List<Task>();
                //Cook spaghetti
                //3 pots available, so we put the maximum amount in the first pot and split the rest
                cookingTasks.Add(SpaghettiMakerAsync.CookSpaghettiAsync(pot1, 200));
                cookingTasks.Add(SpaghettiMakerAsync.CookSpaghettiAsync(pot2, 75));
                cookingTasks.Add(SpaghettiMakerAsync.CookSpaghettiAsync(pot3, 75));


                //Same goes for the sauce, we put the max. amount in the first pot and split the rest
                for(int i = 0; i < 2; )
                {
                    await Task.WhenAny(cookingTasks);
                    i++;
                    if(i == 1)
                    {
                        //Put maximum amount in pot
                        cookingTasks.Add(SpaghettiMakerAsync.CookTomatosauceAsync(pot1, 150));
                    }else if(i == 2)
                    {
                        //Put remaining 50g in pot
                        cookingTasks.Add(SpaghettiMakerAsync.CookTomatosauceAsync(pot2, 50));
                    }
                }

                await Task.WhenAll(cookingTasks);
            });
        }
    }
}