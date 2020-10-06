using System;

namespace Xero.Specflow.Helpers.TestData
{
    class BankAccountDataHelper
    {
        public static string GetAccountNameFromBankName(string bankName)
        {
            var accountName = $"{bankName}-{Guid.NewGuid()}";
            return  accountName.Substring(0, 30);
        }

        public static string GetDefaultAccountNumberByBankName(string bankName)
        {
            // TODO support other banks
            switch (bankName)
            {
                case "ANZ(NZ)": return "01-5011-0345678-000";
                default: throw new NotSupportedException("not supported bank: <null>");
            }
        }
    }
}
