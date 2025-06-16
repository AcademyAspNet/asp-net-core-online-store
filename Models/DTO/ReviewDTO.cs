using OnlineStore.Data.Models;

namespace OnlineStore.Models.DTO
{
    public class ReviewDTO
    {
        public string? Author { get; set; }
        public string? Text { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreatedAt { get; set; }

        public static ReviewDTO FromEntity(Review review)
        {
            string author = review.User.FirstName;

            if (review.User.LastName != null)
                author += $" {review.User.LastName[0]}.";

            return new ReviewDTO()
            {
                Author = author,
                Text = review.Text,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt
            };
        }
    }
}
