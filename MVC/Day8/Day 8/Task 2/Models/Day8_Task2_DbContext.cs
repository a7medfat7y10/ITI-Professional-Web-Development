using Microsoft.EntityFrameworkCore;

namespace Task_2.Models
{
    public class Day8_Task2_DbContext:DbContext
    {
        public Day8_Task2_DbContext(DbContextOptions<Day8_Task2_DbContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
