
using Microsoft.Data.SqlClient;
using OnlineStore.Models.Containers;
using OnlineStore.Models.Entities;
using System.Data;

namespace OnlineStore.Data.Repositories.Implementations
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        private Product ReadProduct(SqlDataReader reader)
        {
            return new Product()
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Description = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                Price = reader.GetDecimal(3)
            };
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Price FROM Products";

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        products.Add(ReadProduct(reader));
                    }
                }
            }

            return products;
        }

        private const int PRODUCTS_PER_PAGE = 10;

        public Page<Product> GetAll(int page = 0)
        {
            if (page < 0)
                throw new ArgumentOutOfRangeException("Page number should be positive");

            List<Product> products = new List<Product>();
            int totalProductCount = 0;

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Price FROM Products " +
                                      "ORDER BY Id OFFSET @skipRows ROWS FETCH NEXT @rowsPerPage ROWS ONLY";

                command.Parameters.AddWithValue("@skipRows", page * PRODUCTS_PER_PAGE);
                command.Parameters.AddWithValue("@rowsPerPage", PRODUCTS_PER_PAGE);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        products.Add(ReadProduct(reader));
                    }
                }

                reader.Close();

                command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Products;";

                totalProductCount = (int) command.ExecuteScalar();
            }

            double maxPage = totalProductCount / PRODUCTS_PER_PAGE;

            return new Page<Product>()
            {
                CurrentPage = page,
                MaxPage = (int) Math.Ceiling(maxPage),
                Items = products
            };
        }

        public Product? GetById(long id)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Price FROM Products WHERE Id = @id";
                command.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                reader.Read();

                return ReadProduct(reader);
            }
        }
    }
}
