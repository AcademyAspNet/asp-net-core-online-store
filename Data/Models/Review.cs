namespace OnlineStore.Data.Models
{
    public class Review
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public required Product Product { get; set; }
        public required string Author { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
