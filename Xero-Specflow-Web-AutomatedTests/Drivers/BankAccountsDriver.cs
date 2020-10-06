using FluentAssertions;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Drivers.PageObjects;

namespace Xero.Specflow.Drivers
{
    class BankAccountsDriver: IBankAccountsDriver
    {
        private readonly BrowserDriver _browserDriver;

        public BankAccountsDriver(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        public void AddANewBankAccount(string accountName)
        {
            var bankAccountsPageObjects = new BankAccountsPageObjects(_browserDriver.Current);
            bankAccountsPageObjects.ClickAddBankAccount();

            var addBankAccountPage = new AddBankAccountsPageObjects(_browserDriver.Current);
            addBankAccountPage.FillInNewAccountDetails(accountName);
        }

        public void AssertNewAccount(string accountName)
        {
            var bankAccountsPageObjects = new BankAccountsPageObjects(_browserDriver.Current);
            bankAccountsPageObjects.NotificationBanner.Displayed.Should().Be(true);
            bankAccountsPageObjects.NotificationBanner.Text.Should().MatchRegex($".{accountName} has been added.");
            bankAccountsPageObjects.BankAccounts.Should().ContainSingle(account => account.Text.Contains(accountName));
        }

    }
}
