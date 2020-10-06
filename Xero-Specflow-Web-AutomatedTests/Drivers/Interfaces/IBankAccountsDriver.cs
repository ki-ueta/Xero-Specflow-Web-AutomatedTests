using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Specflow.Drivers.Interfaces
{
    public interface IBankAccountsDriver
    {
        void AddANewBankAccount(string accountName);
        void AssertNewAccount(string accountName);
    }
}
