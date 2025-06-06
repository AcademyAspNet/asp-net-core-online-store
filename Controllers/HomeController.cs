using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineStore.Models.View;
using OnlineStore.Services;
using System.Data;

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
