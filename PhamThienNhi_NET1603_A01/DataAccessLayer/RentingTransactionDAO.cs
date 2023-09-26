using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RentingTransactionDAO
    {
        private readonly FucarRentingManagementContext _context;

        public RentingTransactionDAO()
        {
            _context = new FucarRentingManagementContext();
        }

        public List<RentingTransaction> GetAllTransactions()
        {
            List<RentingTransaction> transactions = _context.RentingTransactions
                 .ToList();
            return transactions;
        }

        public bool AddNewTransaction(RentingTransaction transaction)
        {
            bool result = false;
            _context.RentingTransactions.Add(transaction);
            _context.SaveChanges();
            result = true;

            return result;
        }


        public bool UpdateTransaction(RentingTransaction transaction)
        {
            bool result = false;

            try
            {
                _context.RentingTransactions.Update(transaction);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
