using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext (DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Task.Models.Actor> Actor { get; set; } = default!;

        public DbSet<Task.Models.Movie> Movie { get; set; } = default!;
    }
}
