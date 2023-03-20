using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class Day9DbContext : DbContext
    {
        public Day9DbContext(DbContextOptions<Day9DbContext> options):base(options)
        {
            
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
