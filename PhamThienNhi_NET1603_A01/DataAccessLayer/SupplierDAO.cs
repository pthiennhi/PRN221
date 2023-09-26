using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SupplierDAO
    {
        private readonly FucarRentingManagementContext _context;

        public SupplierDAO()
        {
            _context = new FucarRentingManagementContext();

        }

        public Supplier getSupplierById(int supplierId)
        {
            Supplier supplier = _context.Suppliers.SingleOrDefault(s => s.SupplierId == supplierId);
            return supplier;

        }

        public List<Supplier> getSupplierList()
        {
            List<Supplier> suppliers = _context.Suppliers.ToList();
            return suppliers;

        }
    }
}
