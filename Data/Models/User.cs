namespace OnlineStore.Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
