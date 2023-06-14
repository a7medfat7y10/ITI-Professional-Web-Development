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
    public class DevelopersRepo : GenericRepo<Developer>, IDevelopersRepo
    {
        public DevelopersRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
