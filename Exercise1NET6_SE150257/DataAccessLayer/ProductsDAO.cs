using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class ProductsDAO
{
    public Product GetProductByID (int id)
    {
        var context = new MyStoreContext ();

        Product product = context.Products.SingleOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            throw new Exception("User not found");
        }
        return product;
    }

    public List<Product> GetProducts() {
        var context = new MyStoreContext ();
        var products = context.Products.ToList ();
        return products;
    }

    public void CreateProduct(Product product)
    {
        var context = new MyStoreContext();
        Product tmp = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
        if (tmp != null)
        {
            throw new Exception("Id used");
        }
        context.Products.Add(product);
        context.Database.OpenConnection();
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [MyStore].[dbo].[Products] ON;");
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [MyStore].[dbo].[Products] OFF;");
        } catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.InnerException.Message);
        }
    }


    
}
