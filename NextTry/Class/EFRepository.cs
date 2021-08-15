using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NextTry.Interface;

namespace NextTry.Class
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _DBSet;
        public EFRepository(DbContext context)
        {
            _context = context;
            _DBSet = context.Set<TEntity>();
        }

        async Task IRepository<TEntity>.Create(TEntity item)
        {
            await _DBSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        async Task<TEntity> IRepository<TEntity>.FindById(int id)
        {
            return await _DBSet.FindAsync(id);
        }

        async Task<IEnumerable<TEntity>> IRepository<TEntity>.Get()
        {
            return await Task.Run(() => _DBSet.AsNoTracking().ToListAsync());  
        }

        async Task<IEnumerable<TEntity>> IRepository<TEntity>.Get(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => _DBSet.AsNoTracking().Where(predicate).ToList());
        }

        async Task IRepository<TEntity>.Remove(TEntity item)
        {
            await Task.Run(()=>_DBSet.Remove(item));            
            await _context.SaveChangesAsync();
        }

        async Task IRepository<TEntity>.Update(TEntity item)
        {
            await Task.Run(()=>_context.Entry(item).State = EntityState.Modified);
            await _context.SaveChangesAsync();
        }
    }
}
