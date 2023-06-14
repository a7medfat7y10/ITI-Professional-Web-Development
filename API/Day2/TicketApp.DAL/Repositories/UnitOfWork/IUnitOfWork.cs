using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.DAL.Repositories.Tickets;

namespace TicketApp.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDevelopersRepo Developers { get; }
        ITicketsRepo Tickets { get; }
        IDepartmentsRepo Departments { get; }
        Task<int> SaveAsync();
    }
}
