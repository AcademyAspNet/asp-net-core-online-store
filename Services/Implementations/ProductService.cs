using OnlineStore.Data.Repositories;
using OnlineStore.Models.Entities;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(long id)
        {
            return _productRepository.GetById(id);
        }
    }
}
