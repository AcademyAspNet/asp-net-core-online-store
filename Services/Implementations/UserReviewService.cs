using OnlineStore.Data.Repositories;
using OnlineStore.Models.Entities;

namespace OnlineStore.Services.Implementations
{
    public class UserReviewService : IUserReviewService
    {
        private readonly IUserReviewRepository _userReviewRepository;

        public UserReviewService(IUserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }

        public List<UserReview> GetReviewsForProduct(Product product)
        {
            return _userReviewRepository.GetByProductId(product.Id);
        }
    }
}
