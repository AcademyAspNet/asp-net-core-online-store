using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using System.Data;
using System.Xml.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly string _connectionString;

        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM Products;";

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1)
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public Product? GetProductById(long id)
        {
            foreach (Product product in GetProducts())
            {
                if (product.Id == id)
                    return product;
            }

            return null;
        }
    }
}
