using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers.PageObjects;

namespace Xero.Specflow.Drivers
{
    class LoginDriver: ILoginDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly TestContext _testContext;

        public LoginDriver(BrowserDriver browserDriver, TestContext testContext)
        {
            _browserDriver = browserDriver;
            _testContext = testContext;
        }

        public void Navigate()
        {
            _browserDriver.Current.Navigate().GoToUrl(_testContext.Hostname);
        }

        public void Login(string username, string password)
        {
            var loginPageObject = new LoginPageObject(_browserDriver.Current);
            loginPageObject.LogIn(_testContext.Username, _testContext.Password);

            var dashboardPageObject = new DashboardPageObject(_browserDriver.Current);
            dashboardPageObject.DefaultSelectedBusiness.Should().NotBeNull("there should be at least one business created.");
        }

    }
}
