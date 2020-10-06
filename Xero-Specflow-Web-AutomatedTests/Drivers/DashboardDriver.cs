using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Drivers.PageObjects;

namespace Xero.Specflow.Drivers
{
    class DashboardDriver: IDashboardDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly TestContext _testContext;

        public DashboardDriver(BrowserDriver browserDriver, TestContext testContext)
        {
            _browserDriver = browserDriver;
            _testContext = testContext;
        }

        public void SelectBankAccountMenu()
        {
            var dashboardPageObject = new DashboardPageObject(_browserDriver.Current);
            dashboardPageObject.SelectBankAccounts();

        }
    }
}
