using OnlineStore.Data.Models;

namespace OnlineStore.Models.View
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public required List<Review> Reviews { get; set; }
    }
}
