using BankAppTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppTask.Data.Interface
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
        Task<bool> UpdateAccountBalance(Account account);
        Task<List<Account>> GetAllAccountsForACustomer(int id);

        Task<bool> CreateAccount(Account account);
        Task<Account> GetAccountDetails(string accountNumber);
    }
}
