using BusinessObjects.Models;
using DataAccessLayer;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Supplier GetSupplierById(int supplierId) => new SupplierDAO().getSupplierById(supplierId);

        public List<Supplier> GetSupplierList() => new SupplierDAO().getSupplierList();
       
    }
}
