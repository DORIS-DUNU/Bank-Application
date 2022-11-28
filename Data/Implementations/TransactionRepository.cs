using BankAppTask.Commons;
using BankAppTask.Commons.Interface;
using BankAppTask.Data.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transaction = BankAppTask.Model.Transaction;

namespace BankAppTask.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IJsonHelper _jsonHelper;

        public TransactionRepository(IJsonHelper jsonHelper)
        {
            _jsonHelper = jsonHelper;
        } 
        public async Task<bool> AddTransaction(Transaction transaction)
        {
            return await _jsonHelper.WriteToJson(transaction, FileNames.TransactionStore);
        }

        public async Task<List<Transaction>> GetAllTransactionsForAnAccount(string accountNumber)
        {
            var transactions = (List<Transaction>)await _jsonHelper.ReadFromJson<Transaction>(FileNames.TransactionStore);
            var result = new List<Transaction>();
            if (transactions != null)
            {
                foreach (var item in transactions)
                {
                    if (item.AccountNumber == accountNumber)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
