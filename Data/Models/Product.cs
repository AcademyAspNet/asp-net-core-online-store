using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
