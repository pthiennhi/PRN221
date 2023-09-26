using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.CustomerDAO;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerById(int id) => new CustomerDAO().GetCustomerById(id);

        public Boolean AddNewCustomer(Customer customer) => new CustomerDAO().AddNewCustomer(customer);

        public Boolean DeleteCustomer(Customer customer) => new CustomerDAO().DeleteCustomer(customer);

        public Boolean UpdateCustomer(Customer customer) => new CustomerDAO().UpdateCustomer(customer);
        public List<Customer> GetAllCustomers() => new CustomerDAO().GetAllCustomers();

        public Customer LoginByEmailPassword(string email, string password) => new CustomerDAO().LoginByEmailPassword(email, password);

        public List<Customer> SearchCustomers(string searchTerm, String searchType)
        {
            List<Customer> customers = new CustomerDAO().GetAllCustomers();
            IQueryable<Customer> query = customers.AsQueryable();

            switch (searchType)
            {
                case "Id":
                    if (int.TryParse(searchTerm, out int customerId))
                    {
                        query = query.Where(c => c.CustomerId == customerId);
                    }
                    break;

                case "Name":
                    query = query.Where(c => c.CustomerName.Contains(searchTerm));
                    break;

                case "Email":
                    query = query.Where(c => c.Email.Contains(searchTerm));
                    break;

                case "Phone":
                    query = query.Where(c => c.Telephone.Contains(searchTerm));
                    break;

                default:
                    return new List<Customer>();
            }

            List<Customer> searchResults = query.ToList();
            return searchResults;
        }

        
    }

}
