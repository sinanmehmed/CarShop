using CarShop.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DealerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new MechanicConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Dealer> Dealers { get; set; } = null!;
    }
}