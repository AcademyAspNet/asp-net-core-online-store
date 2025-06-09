using Microsoft.Data.SqlClient;
using OnlineStore.Models.Entities;
using System.Data;

namespace OnlineStore.Data.Repositories.Implementations
{
    public class UserReviewRepository : BaseRepository, IUserReviewRepository
    {
        public UserReviewRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<UserReview> GetByProductId(long productId)
        {
            List<UserReview> reviews = new List<UserReview>();

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT Id, Author, Content, Rating FROM Reviews WHERE ProductId = @productId";
                command.Parameters.Add("@productId", SqlDbType.BigInt).Value = productId;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserReview review = new UserReview()
                        {
                            Id = reader.GetInt64(0),
                            ProductId = productId,
                            Author = reader.GetString(1),
                            Content = reader.GetString(2),
                            Rating = reader.GetByte(3)
                        };

                        reviews.Add(review);
                    }
                }
            }

            return reviews;
        }
    }
}
