using System;
using System.Threading;

namespace BankAppTask.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public static int GlobalID;

        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.Id = Interlocked.Increment(ref GlobalID);
        }
    }
}
