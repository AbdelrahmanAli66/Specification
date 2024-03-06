using Domain;

namespace Service.Contract
{
    public interface IStoreService
    {
        Store? GetById(int id);
        List<Store> GetStores();
        Store AddStore(Store Store);
        Store UpdateStore(Store Store);
        void RemoveStore(int id);
    }
}
