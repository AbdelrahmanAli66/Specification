using Data;
using Domain;
using Repository.Contract;
using Repository.Generic;

namespace Repository
{
    public class StoreRepository(ApplicationDbContext context) : BaseRepository<Store>(context), IStoreRepository
    {
    }
}
