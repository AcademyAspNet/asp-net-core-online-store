namespace OnlineStore.Models.Containers
{
    public class Page<T>
    {
        public required int CurrentPage { get; set; }
        public required int MaxPage { get; set; }
        public required List<T> Items { get; set; }
    }
}
