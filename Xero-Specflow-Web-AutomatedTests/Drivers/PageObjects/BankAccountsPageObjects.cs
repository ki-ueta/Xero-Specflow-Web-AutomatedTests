using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OpenQA.Selenium;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class BankAccountsPageObjects
    {
        private readonly IWebDriver _webDriver;
        private string _AddBankAccountButton = @"//span[@data-automationid=""Add Bank Account-button""]";

        public BankAccountsPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }

        public IWebElement NotificationBanner => _webDriver.FindElement(By.XPath(@"//*[@class=""notify bg-green bigger""]"));
        public IEnumerable<IWebElement> BankAccounts => _webDriver.FindElements(By.XPath(@"//*[@class=""bank-header""]/a"));


        public void ClickAddBankAccount()
        {
            WebElementHelper.WaitUntilElementClickable(_webDriver,
                By.XPath(_AddBankAccountButton));

            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver,
                By.XPath(_AddBankAccountButton));

            RetryHelper.WaitFor(() => _webDriver.Url.EndsWith("/Account/#find"));
        }
    }
}
