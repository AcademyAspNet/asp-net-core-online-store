namespace OnlineStore.Models.Entities
{
    public class UserReview
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public required string Author { get; set; }
        public required string Content { get; set; }
        public int Rating { get; set; }
    }
}
