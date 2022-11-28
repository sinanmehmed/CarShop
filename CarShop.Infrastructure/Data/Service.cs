using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
