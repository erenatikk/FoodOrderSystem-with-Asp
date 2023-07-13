using FoodOrderSystem.Data;
using FoodOrderSystem.Services;
using FoodOrderSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisterManager _registerManager;

        public RegisterController(AppDbContext dbContext)
        {
            _registerManager = new RegisterManager(dbContext);
        }

        [HttpGet]


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                _registerManager.RegisterUser(model.UserName, model.Password, model.Email);

               
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
