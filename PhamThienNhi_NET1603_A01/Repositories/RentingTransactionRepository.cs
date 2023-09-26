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
    public class RentingTransactionRepository : IRentingTransactionRepository
    {
        public bool AddNewTransaction(RentingTransaction transaction)
        {
            return new RentingTransactionDAO().AddNewTransaction(transaction);
        }

        public List<RentingTransaction> GetAllTransactions()
        {
            return new RentingTransactionDAO().GetAllTransactions();
        }

        public bool UpdateTransaction(RentingTransaction transaction)
        {
            return new RentingTransactionDAO().UpdateTransaction(transaction);
        }
    }
}
