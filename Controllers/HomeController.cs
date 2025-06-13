using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineStore.Data.Models;
using OnlineStore.Models.Containers;
using OnlineStore.Models.View;
using OnlineStore.Services;
using System.Data;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] IProductService productService, int page = 0)
        {
            page = Math.Clamp(page, 0, int.MaxValue);
            Page<Product> pageResult = productService.GetProducts(page);

            return View(pageResult);
        }
    }
}
