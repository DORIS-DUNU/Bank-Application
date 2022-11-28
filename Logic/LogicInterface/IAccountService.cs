using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Logic.LogicInterface
{
    public interface IAccountService 
    {
        Task<bool> Deposit(string accountNumber, string amount);
        Task<bool> Withdraw(string accountNumber, string amount);

    }
}
