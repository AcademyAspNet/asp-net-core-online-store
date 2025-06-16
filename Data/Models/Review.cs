namespace OnlineStore.Data.Models
{
    public class Review
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public required Product Product { get; set; }
        public long UserId { get; set; }
        public required User User { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
