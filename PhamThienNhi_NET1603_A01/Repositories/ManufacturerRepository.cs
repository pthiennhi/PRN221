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
    public class ManufacturerRepository : IManufacturerRepository
    {
        public List<Manufacturer> GetAllManufacturer() => new ManufacturerDAO().getAllManufacturer();
       
        public Manufacturer GetManufacturerByid(int id) => new ManufacturerDAO().getManufacturerByid(id);
        
    }
}
