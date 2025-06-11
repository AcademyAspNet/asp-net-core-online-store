using OnlineStore.Models.Entities;

namespace OnlineStore.Services
{
    public interface IUserReviewService
    {
        List<UserReview> GetReviewsForProduct(Product product);
    }
}
