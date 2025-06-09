using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Entities;
using OnlineStore.Services;
using OnlineStore.Services.Implementations;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Product? product = _productService.GetProductById((int) id);

            if (product == null)
                return RedirectToAction("Index", "Home");

            return View(product);
        }
    }
}
