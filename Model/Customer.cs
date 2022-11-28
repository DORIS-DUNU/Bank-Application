using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Model
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        List<Account> Accounts { get; set; }
    }
}

  