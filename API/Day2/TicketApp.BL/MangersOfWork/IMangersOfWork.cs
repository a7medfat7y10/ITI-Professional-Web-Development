using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.BL.DepartmentsManager;
using TicketApp.DAL.Repositories.Tickets;

namespace TicketApp.BL.MangersOfWork
{
    public interface IMangersOfWork
    {
        IDepartmentsManager Departments { get; }
    }
}
