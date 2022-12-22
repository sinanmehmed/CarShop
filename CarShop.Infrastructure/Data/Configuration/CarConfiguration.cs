using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Infrastructure.Data.Configuration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(CreateCars());
        }

        private List<Car> CreateCars()
        {
            var cars = new List<Car>()
            {
                new Car()
                 {
                      Id = 1,
                      Make = "Mercedes-Benz",
                      Model = "E220 AMG Sport",
                      Description = "The car is in perfect condition!",
                      Colour = "Silver",
                      CategoryId = 4,
                      RegNumber = "EF14XAE",
                      Year = 2014,
                      EngineSize = 2200,
                      HorsePower = 231,
                      FuelId = 2,
                      TransmissionId = 2,
                      ImageUrl = "https://www.gcs-germancarspecialist.co.uk/photos/10790/22713893-471d-41d8-b47a-9069e1d15840_i800x600.jpg",
                      Price = 24000.00M,
                      DealerId = 1,
                      BuyerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                 },

                new Car()
                {
                    Id = 2,
                    Make = "BMW",
                    Model = "530d XDrive",
                    Description = "There is a scratch on rear bumper but overall the car is a great runner",
                    Colour = "Black",
                    CategoryId = 2,
                    RegNumber = "SA71VFC",
                    Year = 2021,
                    EngineSize = 3000,
                    HorsePower = 250,
                    FuelId = 2,
                    TransmissionId = 2,
                    ImageUrl = "https://vcache.arnoldclark.com/imageserver/ACRFNV0147DA-S-/800/f",
                    Price = 40000.00M,
                    DealerId = 1                    

                },

                new Car()
                {
                    Id = 3,
                    Make = "Chevrolet",
                    Model = "Captiva LT",
                    Description = "Very good and reliable SUV with 7 seats. This is a perfect family car!",
                    Colour = "White",
                    CategoryId = 3,
                    RegNumber = "WF12GZC",
                    Year = 2021,
                    EngineSize = 2000,
                    HorsePower = 160,
                    FuelId = 1,
                    TransmissionId = 1,
                    ImageUrl = "https://images.clickdealer.co.uk/vehicles/4556/4556096/large2/102784640.jpg",
                    Price = 13000.00M,
                    DealerId = 1                    
                }
            };

            return cars;
        }
    }
}
