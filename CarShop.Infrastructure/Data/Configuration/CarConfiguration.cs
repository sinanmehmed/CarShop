using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Infrastructure.Data.Configuration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            //builder.HasData(CreateCars());
        }

        //private List<Car> CreateCars()
        //{
            
        //}
    }
}
