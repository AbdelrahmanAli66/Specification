using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.Generic;

namespace Repository
{
    public class StoreRepository(ApplicationDbContext context) : BaseRepository<Store>(context), IStoreRepository
    {
        public Store? GetStore(int id)
        {
            return Query().FirstOrDefault(store => store.Id == id);
        }
        public override ICollection<Store> GetAll()
        {
            return Query().Include(store => store.Items).ToList();
        }
    }
}
