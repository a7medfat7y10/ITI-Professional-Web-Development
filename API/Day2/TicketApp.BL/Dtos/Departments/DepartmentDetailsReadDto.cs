using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.BL.Dtos.Tickets;

namespace TicketApp.BL.Dtos.Departments
{
    public class DepartmentDetailsReadDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public IEnumerable<TicketsChildReadDto> Tickets { get; init; }
            = new List<TicketsChildReadDto>();
    }
}
