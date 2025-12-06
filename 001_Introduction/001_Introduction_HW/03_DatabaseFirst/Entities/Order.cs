using System;
using System.Collections.Generic;

namespace DatabaseFirst.Entities;

public partial class Order
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Create { get; set; }

    public DateTime? Update { get; set; }

    public string? Description { get; set; }
}
