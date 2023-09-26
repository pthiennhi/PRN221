using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RentingDetailDAO
    {
        private readonly FucarRentingManagementContext _context;

        public RentingDetailDAO()
        {
            _context = new FucarRentingManagementContext();
        }

        public List<RentingDetail> GetAllRentingDetails()
        {
            List<RentingDetail> rentingDetails = _context.RentingDetails
                 .ToList();
            return rentingDetails;
        }
    }
}
