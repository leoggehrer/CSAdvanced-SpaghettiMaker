namespace SpaghettiMaker.Common.Dishes;

public class Redwine : DishObject
{
    public void Pour()
    {
        Task.Delay(1000).Wait();
    }
}

