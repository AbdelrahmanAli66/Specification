namespace Repository.Contract.Generic
{
    public interface IGenericQuery<T> where T : class
    {
        IQueryable<T> Query();
        Task<ICollection<T>> GetAll(CancellationToken cancellationToken);
        IQueryable<T> ApplySpecification(Specification<T> specification);
    }
}
