using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;

namespace OnlineStore.Services
{
    public interface IUserReviewService
    {
        List<Review> GetReviewsForProduct(Product product);
        void CreateReview(User user, Product product, ReviewDTO reviewDTO);
    }
}
