using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using VM.Domain.Common;
using VM.Domain.Contracts.Presistence;
using VM.Domain.Enums;

namespace VM.Presistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T GetById(long id, Func<IQueryable<T>, IQueryable<T>> includeQuery = null)
        {
            IQueryable<T> query = _dbSet;

            if (includeQuery != null)
            {
                query = includeQuery(query);
            }

            return query.FirstOrDefault(e => EF.Property<long>(e, "Id") == id)
                   ?? Activator.CreateInstance<T>();
        }

        public List<T> GetAll(int pageNumber, int pageSize, string search = null, string sortBy = null, bool isDescending = false)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => EF.Functions.Like(e.ToString(), $"%{search}%"));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = isDescending
                    ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                    : query.OrderBy(e => EF.Property<object>(e, sortBy));
            }

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public IPageResult<T> GetAllPaged(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageSize = 20, int pageIndex = 0)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            int count = query.Count();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var results = query.ToList();

            return new PageResult<T> { Count = count, Results = results };
        }

        public void Add(T entity)
        {
            if (entity != null)
            {
                entity.Status = Status.Active;
                _dbSet.Add(entity);
            }
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void HardDelete(long id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
