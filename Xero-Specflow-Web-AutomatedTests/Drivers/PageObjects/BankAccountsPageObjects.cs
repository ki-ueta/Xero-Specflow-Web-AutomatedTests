using OpenQA.Selenium;
using System.Collections.Generic;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class BankAccountsPageObjects
    {
        private readonly IWebDriver _webDriver;

        private readonly By _addBankAccountButtonByXPath = By.XPath(@"//span[@data-automationid=""Add Bank Account-button""]");
        private By _notificationBannerByXPath = By.XPath(@"//*[@class=""notify bg-green bigger""]");

        public BankAccountsPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IEnumerable<IWebElement> BankAccounts => _webDriver.FindElements(By.XPath(@"//*[@class=""bank-header""]/a"));

        public IWebElement NotificationBanner()
        {
            return WebElementHelper.WaitUntilElementVisible(_webDriver,
                _notificationBannerByXPath);
        }

        public void ClickAddBankAccountButton()
        {
            WebElementHelper.WaitUntilElementClickable(_webDriver,
                _addBankAccountButtonByXPath);
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver,
                _addBankAccountButtonByXPath);
        }
    }
}
