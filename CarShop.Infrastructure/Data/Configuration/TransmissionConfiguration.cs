using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Infrastructure.Data.Configuration
{
    internal class TransmissionConfiguration : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.HasData(CreateTransmissionTypes());
        }

        private List<TransmissionType> CreateTransmissionTypes()
        {
            List<TransmissionType> transmissionTypes = new List<TransmissionType>()
            {
                new TransmissionType()
                {
                    Id = 1,
                    Type = "Manual"
                },

                new TransmissionType()
                {
                    Id = 2,
                    Type = "Automatic"
                }
             };

            return transmissionTypes;
        }
    }
}
