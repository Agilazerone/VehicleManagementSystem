using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using VM.Domain.Common;

namespace VM.Domain.Contracts.Presistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T GetById(long id, Func<IQueryable<T>, IQueryable<T>> includeQuery = null);

        List<T> GetAll(
            int pageNumber,
            int pageSize,
            string search = null,
            string sortBy = null,
            bool isDescending = false);

        void Add(T entity);

        void Update(T entity);

        void HardDelete(long id);

        void SaveChanges();

        IPageResult<T> GetAllPaged(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageSize = 20,
            int pageIndex = 0);
    }
}
