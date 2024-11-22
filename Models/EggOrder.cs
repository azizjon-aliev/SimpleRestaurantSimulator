namespace SimpleRestaurantSim.Models;

public class EggOrder(int quantity, int orderNumber)
{
    public int Quantity { get; } = quantity;
    private int? Quality { get; } = new Random().Next(1, 101);

    public int? GetQuality()
    {
        if (orderNumber >= 2 && orderNumber % 2 == 0)
            return null;
        
        return Quality < 25 ? null : Quality;
    }

    public void Crack()
    {
        if (GetQuality() == null || GetQuality() < 25)
            throw new Exception("Rotten egg detected!");
        
        Console.WriteLine("Cracking egg...");
    }

    public void DiscardShell()
    {
        Console.WriteLine("Discarding shell...");
    }

    public void Cook()
    {
        Console.WriteLine("Cooking egg...");
    }
}