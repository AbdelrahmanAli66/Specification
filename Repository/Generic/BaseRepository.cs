using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Contract.Generic;

namespace Repository.Generic
{
    public abstract class BaseRepository<T> : IGenericAddUpdate<T>, IGenericQuery<T>, IGenericDelete<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _set;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }
        public void Add(T entity) => _set.Add(entity);

        public void Delete(T entity) => _set.Remove(entity);

        public async Task<ICollection<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _set.ToListAsync(cancellationToken);
        }
        public void Update(T entity) => _set.Update(entity);

        public IQueryable<T> Query()
        {
            return _set;
        }
        public IQueryable<T> ApplySpecification(Specification<T> specification)
        {
            IQueryable<T> _query = _set;
            if (specification.Criteria is not null)
            {
                _query = _query.Where(specification.Criteria);
                //_ = specification.IncludeExpressions.Aggregate(_query, (current, includeExpression) => current.Include(includeExpression));
            }
            return _query;
        }
    }
}
