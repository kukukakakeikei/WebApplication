using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected WebApplicationDbContext dbContext { get; set; }
        protected BaseRepository(WebApplicationDbContext repositoryContext)
        {
            dbContext = repositoryContext;
        }
        public IQueryable<T> FindAll() 
        {
            return dbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondtion(Expression<Func<T, bool>> expression) 
        {
            return dbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity) 
        {
            dbContext.Set<T>().Add(entity);
        }
        public void Update(T entity) 
        {
            dbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity) 
        {
            dbContext.Set<T>().Remove(entity);
        }

    }
}
