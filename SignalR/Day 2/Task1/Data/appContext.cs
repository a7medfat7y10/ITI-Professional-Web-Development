using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.Data
{
    public class appContext : DbContext
    {
        public appContext (DbContextOptions<appContext> options)
            : base(options)
        {
        }

        public DbSet<app.Models.Product> Product { get; set; } = default!;

        public DbSet<app.Models.Comment> Comment { get; set; } = default!;
    }
}
