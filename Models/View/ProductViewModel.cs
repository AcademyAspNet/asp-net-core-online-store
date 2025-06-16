using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;

namespace OnlineStore.Models.View
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public required List<ReviewDTO> Reviews { get; set; }
        public ReviewDTO? ReviewModel { get; set; } = new ReviewDTO() { Author = "", Text = "" };
    }
}
