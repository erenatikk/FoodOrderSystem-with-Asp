using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.ViewModels
{
    public class AddRestaurantViewModel
    {
        [Required(ErrorMessage = "Restoran adı zorunludur.")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Restoran adresi zorunludur.")]
        public string RestaurantAddress { get; set; }
    }

}
