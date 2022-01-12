namespace SpaghettiMaker.Common.Dishes;

public class Spaghetti : DishObject
{
    public static int MaxAmount => 200;
    public int AmountInGrams { get; set; }
    public bool IsCooked { get; private set; } = false;
    public static Spaghetti Cook(Pot pot, int amount)
    {
        if (pot is null)
            throw new ArgumentNullException(nameof(pot));

        if (amount > MaxAmount)
            throw new ArgumentOutOfRangeException(nameof(amount));

        if (!pot.IsHeated)
            pot.Heat();

        Task.Delay(20_000).Wait();
        var result = new Spaghetti() { AmountInGrams = amount };
        result.IsCooked = true;

        return result;
    }
}

