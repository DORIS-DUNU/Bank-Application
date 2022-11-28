using BankAppTask.Commons;
using BankAppTask.Commons.Interface;
using BankAppTask.Data.Interface;
using BankAppTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppTask.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IJsonHelper _jsonHelper;

        public AccountRepository(IJsonHelper jsonHelper)
        {
            _jsonHelper = jsonHelper;
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await _jsonHelper.ReadFromJson<Account>(FileNames.AccountStore);
        }

        public async Task<bool> UpdateAccountBalance(Account account)
        {
            var accounts = await GetAllAccounts();
            if (accounts != null)
            {
                foreach (var item in accounts)
                {
                    if (item.AccountNumber == account.AccountNumber)
                        item.Balance = account.Balance;
                }

                return await _jsonHelper.UpdateJson<Account>(accounts, FileNames.AccountStore);
            }

            return false;
        }

        public async Task<List<Account>> GetAllAccountsForACustomer(int id)
        {
            var accounts = (List<Account>)await _jsonHelper.ReadFromJson<Account>(FileNames.AccountStore);
            var result = new List<Account>();
            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    if (account.UserId == id)
                    {
                        result.Add(account);
                    }
                }
            }

            return result;
        }

        public async Task<bool> CreateAccount(Account account)
        {
            return await _jsonHelper.WriteToJson(account, FileNames.AccountStore);
        }

        public async Task<Account> GetAccountDetails(string accountNumber)
        {
            var accounts = await GetAllAccounts();
            Account result = null;
            accounts.ForEach(x =>
            {
                if (x.AccountNumber == accountNumber)
                {
                    result = x;
                }
            });
            return result;
        }
    }
}
