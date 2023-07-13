namespace FoodOrderSystem.Models

{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
       
        public int RestaurantId { get; set; } //Ürünlerin restoranlarla ilişkilendirilmesi için 
        public virtual Restaurant Restaurant { get; set; } //ürünlerin bağlı olduğu restoranı temsil eder
    }
}
