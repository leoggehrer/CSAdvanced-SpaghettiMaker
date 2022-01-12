using SpaghettiMaker.Common.Dishes;

namespace SpaghettiMaker.Logic
{
    public class SpaghettiMakerAsync
    {
        /// <summary>
        /// Starts a task, which pours redwine
        /// </summary>
        /// <returns>Task pouring redwine</returns>
        public static Task<Redwine> PourRedWineAsync()
        {
            return Task.Run(() =>
            {
                var wine = new Redwine();
                Console.WriteLine("Pouring redwine...");
                wine.Pour();
                Console.WriteLine("Redwine is ready!");
                return wine;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Task<Pot> HeatPotAsync()
        {
            return Task.Run(() =>
            {
                var pot = new Pot();
                Console.WriteLine("Heating Pot...");
                pot.Heat();
                Console.WriteLine("Pot is ready");
                return pot;
            });
        }

        public static Task<Spaghetti> CookSpaghettiAsync(Pot pot, int amount)
        {
            if (amount > Spaghetti.MaxAmount)
                throw new ArgumentOutOfRangeException(nameof(amount), "max. 200g");

            return Task.Run(() =>
            {
                Console.WriteLine("Cook spaghetti...");
                var result = Spaghetti.Cook(pot, amount);
                Console.WriteLine("Spaghetti are ready");
                return result;
            });
        }

        public static Task<TomatoSauce> CookTomatosauceAsync(Pot pot, int amount)
        {
            if (amount > Spaghetti.MaxAmount)
                throw new ArgumentOutOfRangeException(nameof(amount), "max. 200g");

            return Task.Run(() =>
            {
                Console.WriteLine("Cook sauce...");
                var result = TomatoSauce.Cook(pot, amount);
                Console.WriteLine("Sauce is ready");

                return result;
            });
        }

        public static Task<Toast[]> ToastBreadAsync(int count)
        {
            if (count < 0)
                throw new ArgumentException(nameof(count), "Illegal state: below 0");

            return Task.Run(async () =>
            {
                Console.WriteLine("Toasting Bread...");

                var tasks = new List<Task<Toast>>();
                for (int i = 0; i < count; i++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        var result = new Toast();
                        result.ToastBread();
                        return result;
                    }));
                }

                //Wait for all toasts to be ready
                await Task.WhenAll(tasks);

                Console.WriteLine("Breads are ready");
                //Collect all toasts from their tasks
                return tasks.Select(t => t.Result).ToArray();
            });
        }

        public static Task<Water> PourWaterAsync()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Pouring water...");

                var result = new Water();
                result.Pour();
                Console.WriteLine("Water is ready");

                return result;
            });
        }
    }
}