using OnlineStore.Data.Models;

namespace OnlineStore.Services
{
    public interface IUserReviewService
    {
        List<Review> GetReviewsForProduct(Product product);
    }
}
