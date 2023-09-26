using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Email { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public byte? CustomerStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
