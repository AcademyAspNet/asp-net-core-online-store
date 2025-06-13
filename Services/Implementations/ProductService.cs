using OnlineStore.Data;
using OnlineStore.Data.Models;
using OnlineStore.Models.Containers;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private const int PRODUCTS_PER_PAGE = 1;

        private readonly ApplicationDbContext _database;

        public ProductService(ApplicationDbContext database)
        {
            _database = database;
        }

        public List<Product> GetProducts()
        {
            return _database.Products.ToList();
        }

        public Page<Product> GetProducts(int page)
        {
            double pages = _database.Products.Count() / PRODUCTS_PER_PAGE;

            return new Page<Product>()
            {
                CurrentPage = page,
                MaxPage = (int) Math.Ceiling(pages),
                Items = _database.Products.ToList() // TODO: Pagination
            };
        }

        public Product? GetProductById(long id)
        {
            return _database.Products.Find(id);
        }
    }
}
