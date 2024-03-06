using Domain;
using Repository.Contract;
using Repository.Contract.Generic;
using Service.Contract;

namespace Service
{
    public class StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork) : IStoreService
    {
        public Store AddStore(Store Store)
        {
            storeRepository.Add(Store);
            unitOfWork.SaveChanges();
            return Store;
        }

        public Store? GetById(int id)
        {
            return storeRepository.GetStore(id);
        }

        public List<Store> GetStores()
        {
            return storeRepository.GetAll().ToList();
        }

        public void RemoveStore(int id)
        {
            Store? store = storeRepository.GetStore(id);
            if (store is not null)
            {
                storeRepository.Delete(store);
                unitOfWork.SaveChanges();
            }
        }

        public Store UpdateStore(Store Store)
        {
            storeRepository.Update(Store);
            unitOfWork.SaveChanges();
            return Store;
        }
    }
}
