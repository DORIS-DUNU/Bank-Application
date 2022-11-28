using System.Text.RegularExpressions;

namespace BankAppTask.Commons
{
    public static class Validators
    {
        public static bool CheckName(string name)
        {
            var strRegex = @"^[A-Z]";

            return PerformRegEx(strRegex, name);
        }

        public static bool CheckEmail(string email)
        {
            var strRegex = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return PerformRegEx(strRegex, email);

        }

        public static bool CheckPassword(string password)
        {
            var strRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";
            return PerformRegEx(strRegex, password);
        }

        public static bool CheckNumber(string phoneNumber)
        {
            var strRegex = @"^[0-9]{11}$";
            return PerformRegEx(strRegex, phoneNumber);
        }

        private static bool PerformRegEx(string pattern, string value)
        {
            var re = new Regex(pattern);
            return re.IsMatch(value);
        }
        
        public static (bool isDecimal, decimal Amount) CheckAmount(string amount)
        {
            return (decimal.TryParse(amount, out decimal value), value);
        }

        public static (bool isLong, long Account) CheckAccountNumber(string account)
        {
            return (long.TryParse(account, out long value), value);
        }
    }
}
