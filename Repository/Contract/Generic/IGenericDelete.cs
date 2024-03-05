namespace Repository.Contract.Generic
{
    public interface IGenericDelete<T> where T : class
    {
        void Delete(T entity);
    }
}
