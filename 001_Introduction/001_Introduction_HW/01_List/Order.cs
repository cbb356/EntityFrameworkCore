using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    internal class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"OrderId: {Id}\nName: {Name}\nCreated: {Create}\nUpdated: {Update}\nDescription: {Description}\n";
        }

    }
}
