using FluentAssertions;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Drivers.PageObjects;
using Xero.Specflow.Infrastructure;

namespace Xero.Specflow.Drivers
{
    class BankAccountsDriver: IBankAccountsDriver
    {
        private readonly BrowserDriver _browserDriver;

        public BankAccountsDriver(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        public void AddANewBankAccount(string bankName, string accountName,string accountNumber)
        {
            var bankAccountsPageObjects = new BankAccountsPageObjects(_browserDriver.Current);
            bankAccountsPageObjects.ClickAddBankAccountButton();

            var addBankAccountPage = new AddBankAccountsPageObjects(_browserDriver.Current);
            addBankAccountPage.FillInNewAccountDetails(bankName,accountName,accountNumber);
        }

        public void AssertNewBankAccount(string accountName)
        {
            var bankAccountsPageObjects = new BankAccountsPageObjects(_browserDriver.Current);
            bankAccountsPageObjects.NotificationBanner().Text.Should().ContainEquivalentOf($"{accountName} has been added");
            bankAccountsPageObjects.BankAccounts.Should().ContainSingle(account => account.Text.Contains(accountName));
        }
    }
}
