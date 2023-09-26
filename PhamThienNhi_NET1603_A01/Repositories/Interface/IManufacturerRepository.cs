using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IManufacturerRepository
    {
        public Manufacturer GetManufacturerByid(int id);
        public List<Manufacturer> GetAllManufacturer();
    }
}
