using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "ID is required")]
        public int ProductId { get; set; } = 0;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name <= 50 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        public int UnitPrice { get; set; }
    }
}
