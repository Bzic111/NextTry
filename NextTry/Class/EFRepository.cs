using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NextTry.Interface;

namespace NextTry.Class
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _DBSet;
        public EFRepository(ContractDbContext context)
        {
            _context = context;
            _DBSet = context.Set<TEntity>();
        }
        public void Create(TEntity item)
        {
            _DBSet.Add(item);
            _context.SaveChanges();
        }
        public TEntity FindById(int id)
        {
            return _DBSet.Find(id);
        }
        public TEntity FindByIdNoTracking(int id)
        {
            var entity = _DBSet.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public IEnumerable<TEntity> Get()
        {
            return _DBSet.AsNoTracking().ToList();  
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _DBSet.AsNoTracking().Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetTracking(Func<TEntity, bool> predicate)
        {
            return _DBSet.Where(predicate).ToList();
        }
        public void Remove(TEntity item)
        {
            _DBSet.Remove(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _DBSet.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public void SaveChanges() => _context.SaveChanges();
        public void Test(int employerId)
        {
            //IEnumerable<Invoice> invoices = _DBSet.Select<Invoice> .All<Invoice>(p => p.EmployerId = employerId)
        }
    }
}
