using SpaghettiMaker.Common.Dishes;

namespace SpaghettiMaker.Logic;
public class DinnerMakerAsync
{
    public static async Task<IEnumerable<DishObject>> MakeAsync()
    {
        var result = new List<DishObject>();
        var sauceAmount = 200;
        var spaghettiAmount = 350;
        var potTasks = new List<Task<Pot>>();
        var sauceOrSpaghettiTasks = new List<Task>();
        var pourTasks = new List<Task>()
            {
                Redwine.PourAsync(),
                Water.PourAsync(),
            };
        var toastTasks = new List<Task>()
            {
                Toast.ToastBreadAsync(),
                Toast.ToastBreadAsync(),
            };

        // Toepfe aufwaermen
        potTasks.Add(Pot.HeatAsync());
        potTasks.Add(Pot.HeatAsync());
        potTasks.Add(Pot.HeatAsync());

        while (sauceAmount > 0 || spaghettiAmount > 0)
        {
            var pot = default(Pot);

            if (potTasks.Count > 0)
            {
                var pt = await Task.WhenAny(potTasks.ToArray());

                pot = pt.Result;
                potTasks.Remove(pt);
            }
            else
            {
                var t = await Task.WhenAny(sauceOrSpaghettiTasks.ToArray());

                if (t is Task<Spaghetti> st)
                {
                    pot = st.Result.Pot;
                    result.Add(st.Result);
                    sauceOrSpaghettiTasks.Remove(t);
                }
                else if (t is Task<TomatoSauce> tt)
                {
                    pot = tt.Result.Pot;
                    result.Add(tt.Result);
                    sauceOrSpaghettiTasks.Remove(t);
                }
            }
            if (pot != null && spaghettiAmount > 0)
            {
                var amount = Math.Min(spaghettiAmount, 200);

                spaghettiAmount -= amount;
                sauceOrSpaghettiTasks.Add(Spaghetti.CookAsync(pot, amount));
            }
            else if (pot != null && sauceAmount > 0)
            {
                var amount = Math.Min(sauceAmount, 150);

                sauceAmount -= amount;
                sauceOrSpaghettiTasks.Add(TomatoSauce.CookAsync(pot, amount));
            }
        }
        await Task.WhenAll(pourTasks.ToArray());
        foreach (var task in pourTasks)
        {
            if (task is Task<Redwine> rt)
                result.Add(rt.Result);
            else if (task is Task<Water> wt)
                result.Add(wt.Result);
        }
        await Task.WhenAll(toastTasks.ToArray());
        foreach (var task in toastTasks)
        {
            if (task is Task<Toast> rt)
                result.Add(rt.Result);
        }
        await Task.WhenAll(sauceOrSpaghettiTasks.ToArray());
        foreach (var task in sauceOrSpaghettiTasks)
        {
            if (task is Task<Spaghetti> st)
                result.Add(st.Result);
            else if (task is Task<TomatoSauce> tt)
                result.Add(tt.Result);
        }
        return result;
    }
}