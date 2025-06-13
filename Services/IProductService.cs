using OnlineStore.Data.Models;
using OnlineStore.Models.Containers;

namespace OnlineStore.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Page<Product> GetProducts(int page);
        Product? GetProductById(long id);
    }
}
