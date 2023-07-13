namespace FoodOrderSystem.ViewModels
{
    public class BuyProductViewModel
    {
        public int ProductId { get; set; }
        public Dictionary<int, string> Products { get; set; } = new Dictionary<int, string>();
    }
}
