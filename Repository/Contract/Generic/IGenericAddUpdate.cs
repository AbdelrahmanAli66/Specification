namespace Repository.Contract.Generic
{
    public interface IGenericAddUpdate<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
    }
}
