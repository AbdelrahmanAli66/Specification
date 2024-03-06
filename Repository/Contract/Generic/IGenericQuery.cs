namespace Repository.Contract.Generic
{
    public interface IGenericQuery<T> where T : class
    {
        IQueryable<T> Query();
        ICollection<T> GetAll();
        IQueryable<T> ApplySpecification(Specification<T> specification);
    }
}
