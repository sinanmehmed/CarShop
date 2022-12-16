using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Infrastructure.Data.Configuration
{
    internal class FuelConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.HasData(CreateFuelTypes());
        }

        private List<FuelType> CreateFuelTypes()
        {
            List<FuelType> fuelTypes = new List<FuelType>()
            {
                new FuelType()
                {
                    Id = 1,
                    Type = "Petrol"
                },

                new FuelType()
                {
                    Id = 2,
                    Type = "Diesel"
                },

                new FuelType()
                {
                    Id = 3,
                    Type = "Electric"
                },

                new FuelType()
                {
                    Id = 4,
                    Type = "Hybrid"
                }

             };

            return fuelTypes;
        }
    }
}
