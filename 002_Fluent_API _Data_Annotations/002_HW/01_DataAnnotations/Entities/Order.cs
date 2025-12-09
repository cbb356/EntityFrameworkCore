using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAnnotations.Entities
{
    internal class Order
    {
        public Guid OrderId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime Create { get; set; }

        [Column(TypeName = "date")] 
        public DateTime? Update { get; set; }

        [Column(TypeName = "nvarchar(400)")] 
        public string? Description { get; set; }
    }
}
