using FoodOrderSystem.Services;
using FoodOrderSystem.Services.Helpers;
using FoodOrderSystem.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly IDataTransferService _dataTransfer;

        public ProductController(ProductManager productManager, IDataTransferService dataTransferService)
        {
            _productManager = productManager;
            _dataTransfer = dataTransferService;

        }

        [HttpPost]
        public IActionResult Buy(BuyProductViewModel viewModel)
        {
            //ViewBag.OrderedProductId = _dataTransfer.ReadData("productId");

            if (ModelState.IsValid)
            {
                _productManager.giveOrder(viewModel.ProductId);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
    }
}
