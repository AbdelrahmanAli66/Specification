using Domain;

namespace Service.Contract
{
    public interface IItemService
    {
        Item? GetById(int id);
        List<Item> GetItems();
        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(int id);

    }
}
