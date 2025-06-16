using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;
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

            List<ReviewDTO> reviews = new List<ReviewDTO>();

            foreach (Review review in _userReviewService.GetReviewsForProduct(product))
            {
                reviews.Add(ReviewDTO.FromEntity(review));
            }

            ProductViewModel model = new ProductViewModel()
            {
                Product = product,
                Reviews = reviews
            };

            return View(model);
        }
    }
}
