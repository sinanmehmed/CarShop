using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Infrastructure.Data.Configuration
{
    internal class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.HasData(CreateGarages());
        }

        private List<Garage> CreateGarages()
        {
            List<Garage> garages = new List<Garage>()
            {
                new Garage()
                {
                    Id = 1,
                    GarageName = "AutoGarage"
                }

             };

            return garages;
        }
    }
}
