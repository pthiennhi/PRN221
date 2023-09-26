using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DemoSlot27_MyService.Models;

namespace DemoSlot27_MyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyStockDbContext context;
        public ProductsController(MyStockDbContext context) => this.context = context;

        //GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => context.Products.ToList();


        // POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return NoContent();
        }
        // GET: ProductsController/Delete/5
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = context.Products.Find(id);
            if (p == null)
                return NotFound();
            context.Products.Remove(p);
            context.SaveChanges();
            return NoContent();
        }
    }
}
