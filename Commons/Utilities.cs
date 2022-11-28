using System;
using System.Security.Cryptography;
using System.Text;

namespace BankAppTask.Commons
{
    public static class Utilities
    {
        public static string RandomDigits(int length)
        {
            var random = new Random();
            var accountNumber = string.Empty;
            for (var i = 0; i < length; i++)
            {
                accountNumber = string.Concat(accountNumber, random.Next(10).ToString());
            }
            return accountNumber;
        }

        public static string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var stringBuilder = new StringBuilder();
                foreach (var b in bytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
