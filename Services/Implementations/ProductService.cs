using OnlineStore.Models.Domain;
using System.Xml.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products = new List<Product>()
        {
            new Product() { Id = 0, Name = "Product 1" },
            new Product() { Id = 1, Name = "Product 2" },
            new Product() { Id = 2, Name = "Product 3" }
        };

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product? GetProductById(int id)
        {
            foreach (Product product in products)
            {
                if (product.Id == id)
                    return product;
            }

            return null;
        }
    }
}
