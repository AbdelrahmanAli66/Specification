using Domain;
using Repository.Contract.Generic;

namespace Repository.Contract
{
    public interface IItemRepository : IGenericQuery<Item>, IGenericAddUpdate<Item>, IGenericDelete<Item>
    {
    }
}
