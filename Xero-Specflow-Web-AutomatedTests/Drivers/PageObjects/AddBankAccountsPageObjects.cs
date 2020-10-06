using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class AddBankAccountsPageObjects
    {
        private readonly IWebDriver _webDriver;

        private By ANZdropdownByXPath = By.XPath(@"//li[text()=""ANZ (NZ)""]");
        private By ContinueButtonById = By.Id("common-button-submit-1015-btnInnerEl");
        private By AccountNameTextBoxById = By.Id("accountname-1037-inputEl");

        public AddBankAccountsPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        
        public IWebElement AccountTypeDropdownBox => _webDriver.FindElement(By.Id("accounttype-1039-trigger-picker"));
        public IWebElement AccountNumberTextBox => _webDriver.FindElement(By.Id("accountnumber-1068-inputEl"));

        public void FillInNewAccountDetails(string accountName)
        {
            WebElementHelper.WaitUntilElementClickable(_webDriver, ANZdropdownByXPath);
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver, ANZdropdownByXPath);

            WebElementHelper.WaitUntilElementClickable(_webDriver, AccountNameTextBoxById).SendKeys(accountName);

            AccountTypeDropdownBox.Click();
            new Actions(_webDriver).SendKeys(Keys.Tab).Perform();

            AccountNumberTextBox.SendKeys("01-5011-0345678-000");


            WebElementHelper.WaitUntilElementClickable(_webDriver, ContinueButtonById);
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver, ContinueButtonById);
        }
    }
}
