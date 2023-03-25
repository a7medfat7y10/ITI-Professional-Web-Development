using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_1_Instructor_API.Models;

namespace Task_1_Instructor_API.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext (DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Task_1_Instructor_API.Models.Instructor> Instructor { get; set; } = default!;

        public DbSet<Task_1_Instructor_API.Models.Department> Department { get; set; } = default!;
    }
}
