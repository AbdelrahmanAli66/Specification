using Domain;
using Repository.Contract.Generic;

namespace Repository.Contract
{
    public interface IStoreRepository:IGenericQuery<Store>,IGenericAddUpdate<Store>,IGenericDelete<Store>
    {
    }
}
