using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.DAL.Repositories.Tickets
{
        public interface IGenericRepo<T> where T : class
        {
            Task<T> GetByIdAsync(int id);
            Task<IQueryable<T>> GetAllAsync();
            IQueryable<T> FindByCondtion(Expression<Func<T, bool>> expression);
            Task AddAsync(T entity);
            Task AddRangeAsync(IEnumerable<T> entities);
            void Update(T entity);
            void UpdateRange(IEnumerable<T> entities);
            void Remove(T entity);
            void RemoveRange(IEnumerable<T> entities);
        }

    }
