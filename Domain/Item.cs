namespace Domain
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
    }
}
