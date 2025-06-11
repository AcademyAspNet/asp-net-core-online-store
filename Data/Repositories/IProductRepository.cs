using OnlineStore.Models.Containers;
using OnlineStore.Models.Entities;

namespace OnlineStore.Data.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Page<Product> GetAll(int page);
        Product? GetById(long id);
    }
}
