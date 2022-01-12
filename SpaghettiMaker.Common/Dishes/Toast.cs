namespace SpaghettiMaker.Common.Dishes;

public class Toast : DishObject
{
    public void ToastBread()
    {
        Task.Delay(10_000).Wait();
    }
}

