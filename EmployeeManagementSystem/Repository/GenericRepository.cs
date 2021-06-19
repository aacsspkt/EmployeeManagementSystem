using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Foundations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly EmployeeManagementSystemContext context;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(EmployeeManagementSystemContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => this.dbSet.Remove(entity));
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                this.dbSet.Update(entity);
                //this.dbSet.Attach(entity);
                //this.context.Entry<TEntity>(entity).State = EntityState.Modified;
            });
        }

        public IIncludableQueryable<TEntity, object> Include(Expression<Func<TEntity, object>> navigationPropertyPath)
        {
            return this.dbSet.Include(navigationPropertyPath);
        }
    }
}
