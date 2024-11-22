namespace SimpleRestaurantSim.Models;

public class Employee
{
    private object? LastOrder { get; set; }
    private int OrderCount { get; set; }

    public object NewRequest(string menuItem, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        object order;
        
        if (OrderCount % 3 == 2)
        {
            order = menuItem.ToLower() switch
            {
                "chicken" => new EggOrder(quantity: quantity, orderNumber: OrderCount),
                "egg" => new ChickenOrder(quantity),
                _ => throw new ArgumentException($"Invalid menu item: {menuItem}")
            };
        }
        else
        {
            order = menuItem.ToLower() switch
            {
                "chicken" => new ChickenOrder(quantity),
                "egg" => new EggOrder(quantity: quantity, orderNumber: OrderCount),
                _ => throw new ArgumentException($"Invalid menu item: {menuItem}")
            };
        }

        OrderCount++;
        LastOrder = order;

        Console.WriteLine($"OrderCount: {OrderCount}, LastOrder: {LastOrder}, quantity: {quantity}");
        return order;
    }

    public object CopyRequest()
    {
        if (LastOrder == null)
            throw new InvalidOperationException("No previous request to copy!");

        return LastOrder switch
        {
            ChickenOrder chicken => new ChickenOrder(chicken.Quantity),
            EggOrder egg => new EggOrder(quantity: egg.Quantity, orderNumber: OrderCount),
            _ => throw new InvalidOperationException("Unknown order type in LastOrder.")
        };
    }

    public string Inspect(object order)
    {
        return order switch
        {
            ChickenOrder => "No inspection required for chicken.",
            EggOrder egg => $"Egg quality: {egg.GetQuality() ?? -1}",
            _ => throw new ArgumentException("Unknown order type passed for inspection.")
        };
    }

    public string PrepareFood(object order)
    {
        switch (order)
        {
            case ChickenOrder chicken:
                for (int i = 0; i < chicken.Quantity; i++)
                    chicken.CutUp();
                chicken.Cook();
                return "Chicken prepared successfully.";

            case EggOrder egg:
                for (int i = 0; i < egg.Quantity; i++)
                {
                    try
                    {
                        egg.Crack();
                    }
                    catch (Exception ex)
                    {
                        return $"Failed to prepare egg {i + 1}: {ex.Message}";
                    }

                    egg.DiscardShell();
                }

                egg.Cook();
                return "Eggs prepared successfully.";

            default:
                throw new ArgumentException("Unknown order type passed for preparation.");
        }
    }
}