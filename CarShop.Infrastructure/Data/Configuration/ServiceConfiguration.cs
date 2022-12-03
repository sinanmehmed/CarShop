using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(CreateServices());
        }

        private List<Service> CreateServices()
        {
            var services = new List<Service>()
            {
                new Service()
                 {
                      Id = 1,
                      ServiceName = "Engine Oil and Filters",
                      Price = 180.00M

                 },

                new Service()
                 {
                      Id = 2,
                      ServiceName = "Tyres",
                      Price = 600.00M

                 },

                new Service()
                 {
                      Id = 3,
                      ServiceName = "MOT",
                      Price = 50.00M

                 },

                new Service()
                 {
                      Id = 4,
                      ServiceName = "Windcreen",
                      Price = 250.00M

                 },

                new Service()
                 {
                      Id = 5,
                      ServiceName = "Timming Belt",
                      Price = 750.00M

                 },

                new Service()
                 {
                      Id = 6,
                      ServiceName = "Clutch",
                      Price = 1300.00M

                 },

                new Service()
                 {
                      Id = 7,
                      ServiceName = "Cooling System",
                      Price = 300.00M

                 },

                new Service()
                 {
                      Id = 8,
                      ServiceName = "Fuel Pump and Turbo",
                      Price = 1000.00M

                 },

                new Service()
                 {
                      Id = 9,
                      ServiceName = "Battery",
                      Price = 200.00M

                 },

                new Service()
                 {
                      Id = 10,
                      ServiceName = "Suspension",
                      Price = 400.00M

                 },

            };

            return services;
        }
    }
}
