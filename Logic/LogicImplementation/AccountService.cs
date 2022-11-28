using BankAppTask.Data.Interface;
using BankAppTask.Logic.LogicInterface;
using System;
using System.Threading.Tasks;
using Transaction = BankAppTask.Model.Transaction;

namespace BankAppTask.Logic
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<bool> Deposit(string accountNumber, string amount)
        {
            var account = await _accountRepository.GetAccountDetails(accountNumber);
            account.Balance += Convert.ToDouble(amount);
            bool check = await _accountRepository.UpdateAccountBalance(account);
            if (check)
            {
                var transaction = new Transaction()
                {
                    AccountNumber = accountNumber,
                    Description = "Deposit Money",
                    Amount = amount,
                    Balance = account.Balance.ToString()
                };

                await _transactionRepository.AddTransaction(transaction);
                return true;
            }
            return false;
        }

        public async Task<bool> Withdraw(string accountNumber, string amount)
        {
            var account = await _accountRepository.GetAccountDetails(accountNumber);
            double minBalance = account.AccountType == "Saving" ? 1000.0 : 0.0;
            double amt = Convert.ToDouble(amount);
            if (amt <= account.Balance - minBalance)
            {
                account.Balance -= amt;
                bool check = await _accountRepository.UpdateAccountBalance(account);
                if (check)
                {
                    var trans = new Transaction()
                    {
                        AccountNumber = accountNumber,
                        Description = "Withdraw Money",
                        Amount = amount,
                        Balance = account.Balance.ToString()

                    };

                    await _transactionRepository.AddTransaction(trans);
                }
                return true;
            }
            return false;

        }
    }
}


