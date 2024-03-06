using Domain;
namespace Data
{
    public static class SeedData
    {
        public static List<Store> GetStores()
        {
            return
            [
                new() {
                    Id = 1,
                    Name = "Store 1"
                },
                new() {
                    Id = 2,
                    Name = "Store 2"
                }
            ];
        }
        public static List<Item> GetItems()
        {
            return
            [
                new Item { Id = 1, Name = "Item 1", StoreId = 1 },
                new Item { Id = 2, Name = "Item 2", StoreId = 1 },
                new Item { Id = 3, Name = "Item A", StoreId = 2 },
                new Item { Id = 4, Name = "Item B", StoreId = 2 }
            ];
        }
    }

}
