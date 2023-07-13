using FoodOrderSystem.Data;
using FoodOrderSystem.Models;
using FoodOrderSystem.Services;
using FoodOrderSystem.Services.Helpers;
using FoodOrderSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly AdminManager _adminManager;
    private readonly IDataTransferService _dataTransfer;

    public AdminController(AppDbContext dbContext, IDataTransferService dataTransferService)
    {
        _dbContext = dbContext;
        _adminManager = new AdminManager(dbContext);
        _dataTransfer = dataTransferService;
    }

    public IActionResult Index()
    {
        var viewModel = new AdminViewModel
        {
            TotalProducts = _dbContext.Products.Count(),
            TotalUsers = _dbContext.Users.Count(),
            TotalOrders = _dbContext.Orders.Count()
        };
        viewModel.Restaurants = _dbContext.Restaurants.ToList();
        viewModel.Products = _dbContext.Products.ToList();
        ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");

       

        return View(viewModel);
    }


    public IActionResult AddProduct()
    {
        ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(AddProductViewModel model)
    {
        ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
        if (ModelState.IsValid)
        {
            var product = new Product
            {
                Name = model.ProductName,
                Price = model.ProductPrice,
                RestaurantId = model.RestaurantId
            };
            _adminManager.AddProduct(product);

            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult RemoveProduct(int productId)
    {
        ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
        var product = _dbContext.Products.Find(productId);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();

    }

    public IActionResult AddRestaurant()
    {
        ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
        return View();
    }

    [HttpPost]
    public IActionResult AddRestaurant(AddRestaurantViewModel model)
    {
        if (ModelState.IsValid)
        {
            var restaurant = new Restaurant
            {
                Name = model.RestaurantName,
                Address = model.RestaurantAddress
            };

            _adminManager.AddRestaurant(restaurant);

            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult RemoveRestaurant(int restaurantId)
    {
        ViewBag.LoggedInUserName = _dataTransfer.ReadData("username");
        var restaurant = _dbContext.Restaurants.Find(restaurantId);
        if (restaurant != null)
        {
            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult ShowOrders()
    {
        var orders = _dbContext.Orders.ToList();
        return View(orders);
    }
}
