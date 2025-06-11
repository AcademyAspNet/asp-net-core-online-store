using OnlineStore.Models.Entities;

namespace OnlineStore.Models.View
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public required List<UserReview> Reviews { get; set; }
    }
}
