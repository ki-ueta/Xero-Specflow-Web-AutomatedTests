namespace Xero.Specflow.Drivers.Interfaces
{
    public interface IBankAccountsDriver
    {
        void AddANewBankAccount(string bankName, string accountName, string accountNumber);
        void AssertNewBankAccount(string accountName);
    }
}
