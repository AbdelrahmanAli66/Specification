using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.Generic;

namespace Repository
{
    public class ItemRepository(ApplicationDbContext context) : BaseRepository<Item>(context), IItemRepository
    {
        public Item? GetItem(int id)
        {
            return Query().FirstOrDefault(item => item.Id == id);
        }
    }
}
