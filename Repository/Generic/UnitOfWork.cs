using Data;
using Repository.Contract.Generic;


namespace Repository.Generic
{
    public class UnitOfWork(ApplicationDbContext context) : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
