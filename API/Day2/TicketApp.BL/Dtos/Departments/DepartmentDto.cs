using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.BL.Dtos.Departments
{
   
   //public record DepartmentDto(int Id,string Name);

    public class DepartmentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }

}
