using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;

namespace OnlineStore.Services.Implementations
{
    public class UserReviewService : IUserReviewService
    {
        private readonly ApplicationDbContext _database;

        public UserReviewService(ApplicationDbContext database)
        {
            _database = database;
        }

        public void CreateReview(User user, Product product, ReviewDTO reviewDTO)
        {
            if (reviewDTO.Text == null)
                throw new ArgumentNullException("Review text is not specified");

            if (reviewDTO.Rating == null)
                throw new ArgumentNullException("Review rating is not specified");

            Review review = new Review()
            {
                Product = product,
                User = user,
                Text = reviewDTO.Text,
                Rating = (int) reviewDTO.Rating
            };

            _database.Reviews.Add(review);
            _database.SaveChanges();
        }

        public List<Review> GetReviewsForProduct(Product product)
        {
            return _database.Reviews
                .Where(review => review.ProductId == product.Id)
                .Include(review => review.User)
                .ToList();
        }
    }
}
