using Pustok.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Repositories.Abstractions.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<int> SaveChangesAsync();
    }
}
