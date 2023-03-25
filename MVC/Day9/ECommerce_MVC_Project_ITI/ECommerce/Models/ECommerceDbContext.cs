using ECommerce.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class ECommerceDbContext:IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ECommerceDb;Integrated Security=true;Encrypt=false");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RegisterAccountViewModel>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<LoginViewModel>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<RoleViewModel>(entity =>
            {
                entity.HasNoKey();

            });
        }
        public DbSet<ECommerce.ViewModel.RegisterAccountViewModel> RegisterAccountViewModel { get; set; } = default!;
        public DbSet<ECommerce.ViewModel.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<ECommerce.ViewModel.RoleViewModel> RoleViewModel { get; set; } = default!;
        //our own dataset will be written here
    }
}
