using FoodOrderSystem.Data;
using FoodOrderSystem.Models;
using FoodOrderSystem.Services.Helpers;
using FoodOrderSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IDataTransferService _dataTransfer;


        public HomeController(AppDbContext dbContext, IDataTransferService dataTransferService)
        {
            _dbContext = dbContext;
            _dataTransfer = dataTransferService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Anasayfam";
            ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
            var favoriteRestaurants = GetRandomFavoriteRestaurants(3);
            return View(favoriteRestaurants);
        }

        private List<Restaurant> GetRandomFavoriteRestaurants(int count)
        {
            var favoriteRestaurants = _dbContext.Restaurants
                .OrderBy(r => Guid.NewGuid())
                .Take(count)
                .ToList();

            return favoriteRestaurants;
        }
        public IActionResult ListRestaurants()
        {

            ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
            var restaurants = _dbContext.Restaurants.ToList();
            return View(restaurants);
        }

        public IActionResult ShowProducts(int id)
        {
            ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
            var restaurant = _dbContext.Restaurants.Include(r => r.Products).FirstOrDefault(r => r.Id == id);
            var products = restaurant?.Products.ToList();
            var viewModel = new BuyProductViewModel()
            {
                Products = products!.ToDictionary(k => k.Id, v => $"{v.Name}-----{v.Price.ToString("C")}")
            };
            return View(viewModel);
        }



    }
}
