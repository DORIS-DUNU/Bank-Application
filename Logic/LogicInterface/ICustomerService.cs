using BankAppTask.Model;
using System.Threading.Tasks;

namespace BankAppTask.Logic.LogicInterface
{
    public interface ICustomerService
    {
        Task<Customer> Login(string email, string password);
    }
}
