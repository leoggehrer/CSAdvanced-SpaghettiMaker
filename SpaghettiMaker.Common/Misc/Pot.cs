namespace SpaghettiMaker.Common.Dishes;

public class Pot
{
    public bool IsHeated { get; set; } = false;
    public bool InUse { get; set; } = false;
    public void Heat()
    {
        Task.Delay(10_000).Wait();
        IsHeated = true;
    }
}