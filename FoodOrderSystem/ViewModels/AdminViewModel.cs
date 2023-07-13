using FoodOrderSystem.Models;

public class AdminViewModel
{
    public List<Restaurant> Restaurants { get; set; }
    public List<Product> Products { get; set; }
    public int TotalProducts { get; set; }
    public int TotalUsers { get; set; }
    public int TotalOrders { get; set; }


}
