using System.Linq.Expressions;
using rsiot.Contracts.Repositories;

namespace rsiot.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll() =>
            _context.Set<T>();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression);

        public void Create(T entity) =>
            _context.Set<T>().Add(entity);

        public void Delete(T entity) =>
            _context.Set<T>().Remove(entity);

        public void Update(T entity) =>
            _context.Set<T>().Update(entity);
    }
}
