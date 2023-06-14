using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.BL.Dtos.Tickets
{
    public class TicketsChildReadDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int DevelopersCount { get; set; }
    }
}
