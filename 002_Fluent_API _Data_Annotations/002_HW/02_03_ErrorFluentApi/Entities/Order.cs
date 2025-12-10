using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErrorFluentApi.Entities
{
    internal class Order
    {
        public Guid OrderId { get; set; }
        public int OrderAlterId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime Create { get; set; }

        [Column(TypeName = "date")] 
        public DateTime? Update { get; set; }

        [Column(TypeName = "nvarchar(400)")] 
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}\nName: {Name}\nCreated: {Create}\nUpdated: {Update}\nDescription: {Description}\n";
        }
    }
}
