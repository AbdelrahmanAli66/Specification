using Domain;
using Repository.Contract;
using Repository.Contract.Generic;
using Service.Contract;

namespace Service
{
    public class ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork) : IItemService
    {
        public Item AddItem(Item item)
        {
            itemRepository.Add(item);
            unitOfWork.SaveChanges();
            return item;
        }

        public Item? GetById(int id)
        {
            return itemRepository.GetItem(id);
        }

        public List<Item> GetItems()
        {
            return itemRepository.GetAll().ToList();
        }

        public void RemoveItem(int id)
        {
            Item? item = itemRepository.GetItem(id);
            if(item is not null)
            {
                itemRepository.Delete(item);
                unitOfWork.SaveChanges();
            }
            
        }

        public Item UpdateItem(Item item)
        {
            itemRepository.Update(item);
            unitOfWork.SaveChanges();
            return item;
        }
    }
}
