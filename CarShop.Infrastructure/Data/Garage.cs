using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data
{
    public class Garage
    {
        public Garage()
        {
            Mechanics = new List<Mechanic>();
            Services = new List<Service>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GarageName { get; set; } = null!;

        public List<Mechanic> Mechanics { get; set; }

        public List<Service> Services { get; set; }
    }
}
