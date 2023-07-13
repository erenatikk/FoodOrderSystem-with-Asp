using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Ürün adı gereklidir.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün fiyatı gereklidir.")]
        [Range(0, double.MaxValue, ErrorMessage = "Geçerli bir fiyat girin.")]
        public decimal ProductPrice { get; set; }
        public int RestaurantId { get; set; }

    }

}
