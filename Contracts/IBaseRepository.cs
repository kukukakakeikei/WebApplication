using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IBaseRepository<T> //基础仓储接口，泛型
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondtion(Expression<Func<T, bool>> exception);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
