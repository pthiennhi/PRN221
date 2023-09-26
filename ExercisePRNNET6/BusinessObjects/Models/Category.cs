using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public string? CategoryNote { get; set; }

    public virtual ICollection<FlowerBouquet> FlowerBouquets { get; set; } = new List<FlowerBouquet>();
}
