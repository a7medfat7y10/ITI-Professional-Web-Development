using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketApp.DAL.Data.Context;
using  TicketApp.DAL.Repositories.Tickets;

namespace TicketApp.DAL.Repositories.Tickets
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IQueryable<T>> GetAllAsync() => await Task.FromResult(_dbSet.AsNoTracking());

        public IQueryable<T> FindByCondtion(Expression<Func<T, bool>> expression) => _dbSet.AsNoTracking().Where(expression);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);

        public void Remove(T entity) => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }


    //public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression) => _context.Set<T>().AsNoTracking().Where(expression);

    //public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression) => await _context.Set<T>().Where(expression).ToListAsync();

    //public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    //public async Task AddRangeAsync(IEnumerable<T> entities) => await _context.Set<T>().AddRangeAsync(entities);

    //public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);

    //public  Task RemoveAsync(T entity)
    //{
    //    _context.Set<T>().Remove(entity);
    //    return Task.CompletedTask;
    //}

    //    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    //    public async Task<IQueryable<T>> GetAllAsync() => _context.Set<T>().AsNoTracking();

    //    public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression) => await Task.FromResult(
    //        _context.Set<T>().Where(expression).AsNoTracking());

    //    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    //    public async Task AddRangeAsync(IEnumerable<T> entities) => await _context.Set<T>().AddRangeAsync(entities);
    //    public async Task UpdateAsync(T entity)
    //    {
    //        _context.Set<T>().Attach(entity);
    //        _context.Entry(entity).State = EntityState.Modified;
    //        await Task.CompletedTask;
    //    }

    //    public async Task RemoveAsync(T entity) => await Task.FromResult(_context.Set<T>().Remove(entity));

    //}


}
//public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

//public async Task<IQueryable<T>> GetAllAsync() => _context.Set<T>().AsNoTracking();

//public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression) => _context.Set<T>().AsNoTracking().Where(expression);

//public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression) => await _context.Set<T>().Where(expression).ToListAsync();

//public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

//public async Task AddRangeAsync(IEnumerable<T> entities) => await _context.Set<T>().AddRangeAsync(entities);

//public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);

//public async Task RemoveAsync(T entity) => _context.Set<T>().Remove(entity);


