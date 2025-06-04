using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] IProductService productService)
        {
            HomePageViewModel model = new HomePageViewModel()
            {
                Products = productService.GetProducts()
            };

            return View(model);
        }
    }
}
