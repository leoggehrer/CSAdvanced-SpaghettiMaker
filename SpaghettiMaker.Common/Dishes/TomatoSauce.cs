namespace SpaghettiMaker.Common.Dishes;

public class TomatoSauce : DishObject
{
    public static int MaxAmount => 150;
    public int AmountInGrams { get; set; }
    public bool IsReady { get; set; }
    public static TomatoSauce Cook(Pot pot, int amount)
    {
        if (pot is null)
            throw new ArgumentNullException(nameof(pot));

        if (amount > MaxAmount)
            throw new ArgumentOutOfRangeException(nameof(amount), "max. 150g");

        if (!pot.IsHeated)
            pot.Heat();

        Task.Delay(15_000).Wait();
        var result = new TomatoSauce() { AmountInGrams = amount };
        result.IsReady = true;

        return result;
    }
}
