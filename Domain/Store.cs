namespace Domain
{
    public class Store
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Item>? Items { get; set; } = [];
    }
}
