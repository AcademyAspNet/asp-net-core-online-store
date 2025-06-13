using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Models;
using OnlineStore.Models.View;
using OnlineStore.Services;
using OnlineStore.Services.Implementations;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserReviewService _userReviewService;

        public ProductController(IProductService productService, IUserReviewService userReviewService)
        {
            _productService = productService;
            _userReviewService = userReviewService;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Product? product = _productService.GetProductById((int) id);

            if (product == null)
                return RedirectToAction("Index", "Home");

            List<Review> reviews = _userReviewService.GetReviewsForProduct(product);

            ProductViewModel model = new ProductViewModel()
            {
                Product = product,
                Reviews = reviews
            };

            return View(model);
        }
    }
}
