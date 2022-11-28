using BankAppTask.Commons;
using BankAppTask.Data.Interface;
using BankAppTask.Model;
using System.Threading.Tasks;
using BankAppTask.Logic.LogicInterface;

namespace BankAppTask.Logic
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Login(string email, string password)
        {
            string hashPassword = Utilities.ComputeSha256Hash(password);
            var users = await _customerRepository.GetAllCustomers();
            foreach (var item in users)
            {
                if (item.EmailAddress == email && item.Password == hashPassword)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
