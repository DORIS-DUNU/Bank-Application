using System.Collections.Generic;
using System.Threading.Tasks;
using Transaction = BankAppTask.Model.Transaction;

namespace BankAppTask.Data.Interface
{
    public interface ITransactionRepository
    {
        Task<bool> AddTransaction(Transaction transaction);

        Task<List<Transaction>> GetAllTransactionsForAnAccount(string accountNumber);

    }
}
