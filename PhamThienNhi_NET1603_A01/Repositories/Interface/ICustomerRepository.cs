using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.CustomerDAO;

namespace Repositories.Interface
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public Customer LoginByEmailPassword(string email, string password);
        public Boolean AddNewCustomer(Customer customer);

        public Boolean DeleteCustomer(Customer customer);

        public Boolean UpdateCustomer(Customer customer);
        public List<Customer> GetAllCustomers();
        List<Customer> SearchCustomers(string searchTerm, String searchType);



    }
}
