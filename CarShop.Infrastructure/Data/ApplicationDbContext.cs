using CarShop.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DealerConfiguration());
            builder.ApplyConfiguration(new FuelConfiguration());
            builder.ApplyConfiguration(new TransmissionConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new MechanicConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new GarageConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Dealer> Dealers { get; set; } = null!;
        public DbSet<Mechanic> Mechanics { get; set; } = null!;
        public DbSet<Garage> Garages { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<ServiceBooking> ServiceBookings { get; set; } = null!;

        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<TransmissionType> TransmissionTypes { get; set; } = null!;

    }
}