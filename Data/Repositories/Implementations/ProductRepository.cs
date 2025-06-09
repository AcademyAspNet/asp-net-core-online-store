
using Microsoft.Data.SqlClient;
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
