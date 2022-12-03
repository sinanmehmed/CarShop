using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data.Configuration
{
    public class MechanicConfiuration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasData(CreateMechanics());
        }

        private List<Mechanic> CreateMechanics()
        {
            var mechanics = new List<Mechanic>()
            {
                new Mechanic()
                 {
                      Id = 1,
                      FirstName = "Pesho",
                      LastName = "Petrov",
                      Rating = 10.00M                                       
                     
                 },

                new Mechanic()
                 {
                      Id = 2,
                      FirstName = "Gosho",
                      LastName = "Petkov",
                      Rating = 8.25M

                 },

                new Mechanic()
                 {
                      Id = 3,
                      FirstName = "Ivelin",
                      LastName = "Radev",
                      Rating = 9.60M

                 },
            };

            return mechanics;
        }
    }
}
