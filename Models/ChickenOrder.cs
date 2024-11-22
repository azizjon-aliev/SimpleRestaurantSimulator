namespace SimpleRestaurantSim.Models;

public class ChickenOrder(int quantity)
{
    public int Quantity { get; } = quantity;

    public void CutUp()
    {
        Console.WriteLine("Cutting up chicken...");
    }

    public void Cook()
    {
        Console.WriteLine("Cooking chicken...");
    }
}