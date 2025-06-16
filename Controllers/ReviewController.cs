using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserReviewService _userReviewService;
        private readonly IUserService _userService;

        public ReviewController(
            IProductService productService,
            IUserReviewService userReviewService,
            IUserService userService
        )
        {
            _productService = productService;
            _userReviewService = userReviewService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateReview(long productId, ReviewDTO reviewDTO)
        {
            Product? product = _productService.GetProductById(productId);

            if (product == null)
                return BadRequest("Product with specified product id not found");

            User? user = _userService.GetUserById(0);

            if (user == null)
                return Unauthorized("User not found");

            _userReviewService.CreateReview(user, product, reviewDTO);

            return RedirectToAction("Index", "Product", new { id = productId });
        }
    }
}
