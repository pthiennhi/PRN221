﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IRentingDetailRepository
    {
        public List<RentingDetail> GetAllRentingDetails();
    }
}
