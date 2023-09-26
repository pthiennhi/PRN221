using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private readonly FucarRentingManagementContext _context;
        public CustomerDAO()
        {
            _context = new FucarRentingManagementContext();
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            return customer;
        }

        public Customer LoginByEmailPassword(string email, string password)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Email == email && c.Password == password);

            return customer;
        }

        public bool AddNewCustomer(Customer customer)
        {
            bool result = false;
            Customer tmp = _context.Customers.SingleOrDefault(c => c.Email == customer.Email);
            if (tmp == null && customer.Email != "admin@FUCarRentingSystem.com")
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteCustomer(Customer customer)
        {
            bool result = false;
            Customer tmp = _context.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
            if (tmp != null)
            {
                tmp.CustomerStatus = 0;
                _context.Entry(tmp).Property(e => e.CustomerStatus).IsModified = true;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool result = false;
            bool hasCustomersWithEmail = _context.Customers.Any(c => c.CustomerId != customer.CustomerId && c.Email == customer.Email);
            if (!hasCustomersWithEmail)
            {
                try
                {
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }

            }

            return result;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> activeCustomers = _context.Customers
                .Where(customer => customer.CustomerStatus == 1)
                .ToList();

            return activeCustomers;
        }


        



    }
}
