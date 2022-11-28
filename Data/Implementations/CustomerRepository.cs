using BankAppTask.Commons;
using BankAppTask.Commons.Interface;
using BankAppTask.Data.Interface;
using BankAppTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppTask.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IJsonHelper _jsonHelper;

        public CustomerRepository(IJsonHelper jsonHelper)
        {
            _jsonHelper = jsonHelper;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _jsonHelper.ReadFromJson<Customer>(FileNames.CustomerStore);
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            return await _jsonHelper.WriteToJson(customer, FileNames.CustomerStore);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customers = await _jsonHelper.ReadFromJson<Customer>(FileNames.CustomerStore);
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    if (customer.Id == id)
                    {
                        return customer;
                    }
                }
            }

            return null;
        }
    }
}
