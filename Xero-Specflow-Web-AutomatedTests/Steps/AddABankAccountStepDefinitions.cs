using TechTalk.SpecFlow;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Helpers.TestData;

namespace Xero.Specflow.Steps
{
    [Binding]
    public class AddABankAccountStepDefinitions
    {
        private string _accountName;
        private string _accountNumber;

        private readonly ILoginDriver _loginDriver;
        private readonly TestRunContext _testRunContext;
        private readonly IDashboardDriver _dashboardDriver;
        private readonly IBankAccountsDriver _bankAccountsDriver;

        public AddABankAccountStepDefinitions( ILoginDriver loginDriver, TestRunContext testRunContext, IDashboardDriver dashboardDriver, IBankAccountsDriver bankAccountsDriver)
        {
            _loginDriver = loginDriver;
            _testRunContext = testRunContext;
            _dashboardDriver = dashboardDriver;
            _bankAccountsDriver = bankAccountsDriver;
        }

        [Given(@"I successfully log in")]
        public void GivenISuccessfullyLogIn()
        {
            _loginDriver.Login(_testRunContext.Username, _testRunContext.Password);
        }

        [When(@"I add (a|an) (.*) bank account")]
        public void WhenIAddABankAccount(string article, string bankName)
        {
            // TODO alternatively, can navigate to bank account page using URL
            _dashboardDriver.SelectBankAccountMenu();

            _accountName = BankAccountDataHelper.GetAccountNameFromBankName(bankName);
            _accountNumber = BankAccountDataHelper.GetDefaultAccountNumberByBankName(bankName);
            _bankAccountsDriver.AddANewBankAccount(bankName,_accountName,_accountNumber);

        }

        [Then(@"a new bank account is recorded in the system")]
        public void ThenANewBankAccountIsAddedOnBankAccountsPage()
        {
            _bankAccountsDriver.AssertNewBankAccount(_accountName);
        }

    }
}
