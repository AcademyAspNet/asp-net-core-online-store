using OnlineStore.Models.Entities;

namespace OnlineStore.Data.Repositories
{
    public interface IUserReviewRepository
    {
        List<UserReview> GetByProductId(long productId);
    }
}
