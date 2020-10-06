using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Drivers.PageObjects;
using Xero.Specflow.Infrastructure;

namespace Xero.Specflow.Drivers
{
    class DashboardDriver: IDashboardDriver
    {
        private readonly BrowserDriver _browserDriver;

        public DashboardDriver(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        public void SelectBankAccountMenu()
        {
            var dashboardPageObject = new DashboardPageObject(_browserDriver.Current);
            dashboardPageObject.SelectBankAccounts();
        }
    }
}
