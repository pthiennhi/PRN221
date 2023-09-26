using BussinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public List<Product> GetProducts () => new ProductsDAO().GetProducts ();

        public Product GetProductById(int id) => new ProductsDAO().GetProductByID (id);

        public void CreateProduct(Product product) => new ProductsDAO().CreateProduct (product);    
    }
}
