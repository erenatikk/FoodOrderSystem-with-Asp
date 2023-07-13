using FoodOrderSystem.Data;

namespace FoodOrderSystem.Services
{
    public class LoginManager
    {
        private readonly AppDbContext _dbContext;

        public LoginManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateUser(string username, string password)
        {

            var user = _dbContext.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            return user != null; 
        }
    }
}
