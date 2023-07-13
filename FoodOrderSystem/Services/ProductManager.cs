using FoodOrderSystem.Data;
using FoodOrderSystem.Models;
using FoodOrderSystem.Services.Helpers;

namespace FoodOrderSystem.Services
{
    public class ProductManager
    {
        private readonly AppDbContext _dbContext;

        private readonly IDataTransferService _dataTransfer;
  

        public ProductManager (AppDbContext dbContext, IDataTransferService dataTransfer)
        {
            _dbContext = dbContext;
            _dataTransfer = dataTransfer;
            
        }
        public void giveOrder(int productId)
        {
            var product =_dbContext.Products.Find(productId);
            var user = _dbContext.Users.FirstOrDefault(p => p.Name == _dataTransfer.ReadData("username"));
            
            if (user == null) { return; }
            if (product == null) { return; }
            
            _dbContext.Orders.Add(new Order()
            {
                ProductId = productId,
                UserId = user.Id,
            });
            _dbContext.SaveChanges();
        }
    }

     
}
