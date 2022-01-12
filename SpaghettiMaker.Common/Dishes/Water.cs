namespace SpaghettiMaker.Common.Dishes;

public class Water : DishObject
{
    public void Pour()
    {
        Task.Delay(1000).Wait();
    }
}
