using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NextTry.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate);
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
}
