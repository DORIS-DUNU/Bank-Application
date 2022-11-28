using BankAppTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Data.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<bool> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
    }
}
