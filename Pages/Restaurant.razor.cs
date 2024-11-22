using Microsoft.AspNetCore.Components;
using SimpleRestaurantSim.Models;

namespace SimpleRestaurantSim.Pages;

public partial class Restaurant : ComponentBase
{
    private string _menuItem = "chicken";
    private int _quantity = 1;
    private string _resultMessage = string.Empty;

    private readonly Employee _employee = new();

    private void SubmitRequest()
    {
        try
        {
            var order = _employee.NewRequest(_menuItem, _quantity);
            _resultMessage = _employee.Inspect(order);
        }
        catch (Exception ex)
        {
            _resultMessage = ex.Message;
        }
    }

    private void CopyRequest()
    {
        try
        {
            var order = _employee.CopyRequest();
            _resultMessage = _employee.Inspect(order);
        }
        catch (Exception ex)
        {
            _resultMessage = ex.Message;
        }
    }

    private void PrepareFood()
    {
        try
        {
            var order = _employee.CopyRequest();
            _resultMessage = _employee.PrepareFood(order);
        }
        catch (Exception ex)
        {
            _resultMessage = ex.Message;
        }
    }
}