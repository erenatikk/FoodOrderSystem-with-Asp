using FoodOrderSystem.Data;
using FoodOrderSystem.Models;

namespace FoodOrderSystem.Services
{
    public class AdminManager
    {
        private readonly AppDbContext _dbContext;

        public AdminManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public void RemoveProduct(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }
        public void RemoveRestaurant(int restaurantId)
        {
            var restaurant = _dbContext.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                _dbContext.SaveChanges();
            }
        }
    }
}
