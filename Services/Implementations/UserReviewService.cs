using OnlineStore.Data;
using OnlineStore.Data.Models;

namespace OnlineStore.Services.Implementations
{
    public class UserReviewService : IUserReviewService
    {
        private readonly ApplicationDbContext _database;

        public UserReviewService(ApplicationDbContext database)
        {
            _database = database;
        }

        public List<Review> GetReviewsForProduct(Product product)
        {
            return _database.Reviews
                .Where(review => review.ProductId == product.Id)
                .ToList();
        }
    }
}
