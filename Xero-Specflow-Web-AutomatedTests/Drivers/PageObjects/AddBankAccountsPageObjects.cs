using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class AddBankAccountsPageObjects
    {
        private readonly IWebDriver _webDriver;

        private readonly By _anzDropdownByXPath = By.XPath(@"//li[text()=""ANZ (NZ)""]");
        private readonly By _continueButtonById = By.Id("common-button-submit-1015-btnInnerEl");
        private readonly By _accountNameTextBoxById = By.Id("accountname-1037-inputEl");

        public AddBankAccountsPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        
        public IWebElement AccountTypeDropdownBox => _webDriver.FindElement(By.Id("accounttype-1039-trigger-picker"));
        public IWebElement AccountNumberTextBox => _webDriver.FindElement(By.Id("accountnumber-1068-inputEl"));

        public void SelectBankName(string bankName)
        {
            By elementLocator;

            // TODO support other banks
            switch (bankName)
            {
                case "ANZ(NZ)": elementLocator = _anzDropdownByXPath;
                    break;
                default: throw new NotSupportedException("not supported bank: <null>");
            }

            WebElementHelper.WaitUntilElementClickable(_webDriver, elementLocator);
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver, elementLocator);
        }

        public void InputAccountName(string accountName)
        {
            WebElementHelper.WaitUntilElementClickable(_webDriver, _accountNameTextBoxById).SendKeys(accountName);
        }

        public void SelectDefaultAccountType()
        {
            // TODO support other account type
            AccountTypeDropdownBox.Click();
            // select the first displayed account type in the dropdown box.
            new Actions(_webDriver).SendKeys(Keys.Tab).Perform();
        }

        public void InputAccountNumber(string accountNumber)
        {
            AccountNumberTextBox.SendKeys(accountNumber);
            // select the first displayed account type in the dropdown box.
            new Actions(_webDriver).SendKeys(Keys.Tab).Perform();
        }

        public void ClickSubmitButton()
        {
            WebElementHelper.WaitUntilElementVisible(_webDriver, _continueButtonById);
            WebElementHelper.WaitUntilElementClickable(_webDriver, _continueButtonById);
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver, _continueButtonById);
        }

        public void FillInNewAccountDetails(string bankName, string accountName, string accountNumber)
        {
            SelectBankName(bankName);

            InputAccountName(accountName);

            SelectDefaultAccountType();
             
            InputAccountNumber(accountNumber);

            ClickSubmitButton();
        }
    }
}
