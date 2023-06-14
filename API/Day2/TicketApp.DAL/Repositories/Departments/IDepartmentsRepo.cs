using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.DAL.Data.Models;

namespace TicketApp.DAL.Repositories.Tickets
{
    public interface IDepartmentsRepo : IGenericRepo<Department>
    {
        Task<Department?> GetWithTicketsWithDevelopersById(int id);
    }
}
