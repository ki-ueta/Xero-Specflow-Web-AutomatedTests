using FluentAssertions;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Drivers.PageObjects;
using Xero.Specflow.Infrastructure;

namespace Xero.Specflow.Drivers
{
    class LoginDriver: ILoginDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly TestRunContext _testRunContext;

        public LoginDriver(BrowserDriver browserDriver, TestRunContext testRunContext)
        {
            _browserDriver = browserDriver;
            _testRunContext = testRunContext;
        }
        
        public void Login(string username, string password)
        {
            var loginPageObject = new LoginPageObject(_browserDriver.Current);
            loginPageObject.LogIn(_testRunContext.Username, _testRunContext.Password);

            var dashboardPageObject = new DashboardPageObject(_browserDriver.Current);
            dashboardPageObject.DefaultSelectedBusiness.Should().NotBeNull("there should be at least one business created.");
        }

    }
}
