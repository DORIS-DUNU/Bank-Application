using System;

namespace BankAppTask.Model

{
    public class Transaction : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction()
        {
            this.TransactionDate = DateTime.Now;
        }

    }
}

