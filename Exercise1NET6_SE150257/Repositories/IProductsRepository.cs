using BussinessObjects.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductsRepository
    {
        public List <Product> GetProducts();

        public Product GetProductById(int id);

        public void CreateProduct(Product product);
    }
}
