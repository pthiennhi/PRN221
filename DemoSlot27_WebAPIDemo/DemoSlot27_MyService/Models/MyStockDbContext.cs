using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSlot27_MyService.Models
{
    public class MyStockDbContext : DbContext
    {
        public MyStockDbContext(DbContextOptions<MyStockDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
