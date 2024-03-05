using Domain;

namespace Service.Contract
{
    public interface IStoreService
    {
        Store? GetById(int id);
        List<Store> GetStores();
        void AddStore(Store Store);
        void UpdateStore(Store Store);
        void RemoveStore(int id);
    }
}
