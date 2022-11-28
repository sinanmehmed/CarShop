using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Hatchback"
                },

                new Category()
                {
                    Id = 2,
                    Name = "Estate"
                },

                new Category()
                {
                    Id = 3,
                    Name = "SUV"
                },

                new Category()
                {
                    Id = 4,
                    Name = "Saloon"
                },

                new Category()
                {
                    Id = 5,
                    Name = "Coupe"
                },

                new Category()
                {
                    Id = 6,
                    Name = "Convertible"
                },

                new Category()
                {
                    Id = 7,
                    Name = "Pickup"
                }

             };

            return categories;
        }
    }
}
