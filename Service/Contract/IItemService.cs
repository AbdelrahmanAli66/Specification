using Domain;

namespace Service.Contract
{
    public interface IItemService
    {
        Item? GetById(int id);
        List<Item> GetItems();
        Item AddItem(Item item);
        Item UpdateItem(Item item);
        void RemoveItem(int id);

    }
}
