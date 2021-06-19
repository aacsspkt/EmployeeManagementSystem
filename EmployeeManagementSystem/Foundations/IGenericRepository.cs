using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Foundations
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<TEntity> GetByIdAsync(int? id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        //void UpdateRange(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        IIncludableQueryable<TEntity, Object> Include(Expression<Func<TEntity, Object>> predicate);
    }
}
