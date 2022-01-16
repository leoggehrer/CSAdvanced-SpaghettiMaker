namespace SpaghettiMaker.Common.Dishes;

public class Pot
{
    public bool IsHeated { get; private set; } = false;
    public static Task<Pot> HeatAsync()
    {
        return Task.Run(() =>
        {
            Task.Delay(10_000).Wait();
            return new Pot()
            {
                IsHeated = true
            };
        });
    }
}