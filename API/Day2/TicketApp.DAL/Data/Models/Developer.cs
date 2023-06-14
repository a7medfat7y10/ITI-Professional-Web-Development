using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.DAL.Data.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

       public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
