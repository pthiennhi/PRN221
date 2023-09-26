using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IRentingTransactionRepository
    {
        public List<RentingTransaction> GetAllTransactions();
        public bool AddNewTransaction(RentingTransaction transaction);
        public bool UpdateTransaction(RentingTransaction transaction);

    }
}
