using FoodOrderSystem.Data;
using FoodOrderSystem.Models;

namespace FoodOrderSystem.Services
{
    public class RegisterManager
    {
        private readonly AppDbContext _dbContext;

        public RegisterManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterUser(string userName, string password, string email)
        {
            
            var user = new User
            {
                Name = userName,
                Email = email,
                Password = password
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
