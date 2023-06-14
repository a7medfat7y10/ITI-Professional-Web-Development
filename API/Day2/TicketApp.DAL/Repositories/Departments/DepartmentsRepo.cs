using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.DAL.Data.Context;
using TicketApp.DAL.Data.Models;

namespace TicketApp.DAL.Repositories.Tickets
{
    public class DepartmentsRepo : GenericRepo<Department>, IDepartmentsRepo
    {
        public DepartmentsRepo(ApplicationDbContext context) : base(context)
        {
        }
        public Task<Department?> GetWithTicketsWithDevelopersById(int id)
        {
            return _context.Set<Department>()
                    .Include(d => d.Tickets)
                        .ThenInclude(p => p.Developers)
                    .FirstOrDefaultAsync(d => d.Id == id);
        }


    }
}
