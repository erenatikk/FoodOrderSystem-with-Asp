using FoodOrderSystem.Data;
using FoodOrderSystem.Services;
using FoodOrderSystem.Services.Helpers;
using FoodOrderSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginManager _loginManager;
        private readonly IDataTransferService _dataTransfer;


        public LoginController(AppDbContext dbContext, IDataTransferService dataTransferService)
        {
            _loginManager = new LoginManager(dbContext);
            _dataTransfer = dataTransferService;
        }
        [HttpGet]


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "admin" && model.Password == "adminpassword")
                {
                    // Admin kullanıcısı giriş yaptı, yönlendirme yap
                    _dataTransfer.AddData("username", model.UserName);
                    return RedirectToAction("Index", "Admin");
                }
                else if (_loginManager.ValidateUser(model.UserName, model.Password))
                {
                    _dataTransfer.AddData("username", model.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage", "Geçersiz kullanıcı adı veya şifre.");
                    ViewBag.ErrorMessage = ModelState["ErrorMessage"].Errors.FirstOrDefault()?.ErrorMessage;

                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Çıkış yapma işlemleri

            return RedirectToAction("Login");
        }
    }
}
