using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ManufacturerDAO
    {
        private readonly FucarRentingManagementContext _context;

        public ManufacturerDAO() {
            _context = new FucarRentingManagementContext();
        }

        public Manufacturer getManufacturerByid(int id) {

            Manufacturer manufacturer = _context.Manufacturers.SingleOrDefault(m => m.ManufacturerId == id);

            return manufacturer;
        }

        public List<Manufacturer> getAllManufacturer() {
            List<Manufacturer> manufacturers = _context.Manufacturers.ToList();

            return manufacturers;
        }
    }
}
