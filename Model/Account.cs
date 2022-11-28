namespace BankAppTask.Model
{

    public class Account : BaseEntity
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }
        public int UserId { get; set; }
    }
}


