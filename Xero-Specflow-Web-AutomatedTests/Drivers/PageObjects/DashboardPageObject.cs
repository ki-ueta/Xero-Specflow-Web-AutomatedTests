using OpenQA.Selenium;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class DashboardPageObject
    {
        private readonly IWebDriver _webDriver;

        public DashboardPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public IWebElement DefaultSelectedBusiness => _webDriver.FindElement(By.ClassName("xui-pageheading--title"));
        public IWebElement AccountingMenu => _webDriver.FindElement(By.Name("navigation-menu/accounting"));

        public void ClickBankAccountsSubMenu (){
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver, By.XPath(@"//a[@data-name=""navigation-menu/accounting/bank-accounts""]"));
        }

        public void SelectBankAccounts()
        {
            AccountingMenu.Click();
            ClickBankAccountsSubMenu();
        }
    }
}
