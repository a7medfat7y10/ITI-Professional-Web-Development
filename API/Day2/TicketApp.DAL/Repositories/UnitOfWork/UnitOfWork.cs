using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.DAL.Data.Context;
using TicketApp.DAL.Repositories.Tickets;

namespace TicketApp.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _context;

        private ITicketsRepo _tickets;
        private IDepartmentsRepo _departments;
        private IDevelopersRepo _developers;

        public UnitOfWork(ApplicationDbContext context) => _context = context;

        public IDevelopersRepo Developers => _developers ?? new DevelopersRepo(_context);
        public ITicketsRepo Tickets => _tickets ?? new TicketsRepo(_context);
        public IDepartmentsRepo Departments => _departments ?? new DepartmentsRepo(_context);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();

    }
}
