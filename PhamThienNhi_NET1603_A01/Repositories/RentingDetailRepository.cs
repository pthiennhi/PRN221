using BusinessObjects.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Repositories
{
    public class RentingDetailRepository :IRentingDetailRepository
    {
        public List<RentingDetail> GetAllRentingDetails() => new RentingDetailDAO().GetAllRentingDetails();
    }
}
