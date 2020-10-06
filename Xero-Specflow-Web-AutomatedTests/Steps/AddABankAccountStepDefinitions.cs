using System;
using TechTalk.SpecFlow;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers;
using Xero.Specflow.Drivers.Interfaces;

namespace Xero.Specflow.Steps
{
    [Binding]
    public class AddABankAccountStepDefinitions
    {
        private string accountName;

        private readonly ILoginDriver _loginDriver;
        private readonly TestContext _testContext;
        private readonly IDashboardDriver _dashboardDriver;
        private readonly IBankAccountsDriver _bankAccountsDriver;

        public AddABankAccountStepDefinitions( ILoginDriver loginDriver, TestContext testContext, IDashboardDriver dashboardDriver, IBankAccountsDriver bankAccountsDriver)
        {
            _loginDriver = loginDriver;
            _testContext = testContext;
            _dashboardDriver = dashboardDriver;
            _bankAccountsDriver = bankAccountsDriver;

            accountName = $"ANZ-{Guid.NewGuid().ToString().Substring(0,26)}";
        }

        [Given(@"I successfully log in")]
        public void GivenISuccessfullyLogIn()
        {
            _loginDriver.Login(_testContext.Username, _testContext.Password);
        }

        [When(@"I add a bank account")]
        public void WhenIClick()
        {
            _dashboardDriver.SelectBankAccountMenu();

            _bankAccountsDriver.AddANewBankAccount(accountName);
        }

        [Then(@"a new bank account is recorded in the system")]
        public void ThenANewBankAccountIsAddedOnBankAccountsPage()
        {
            _bankAccountsDriver.AssertNewAccount(accountName);
        }

    }
}
