using Data;
using Domain;
using Repository.Contract;
using Repository.Generic;

namespace Repository
{
    public class ItemRepository(ApplicationDbContext context) : BaseRepository<Store>(context), IStoreRepository
    {
    }
}
