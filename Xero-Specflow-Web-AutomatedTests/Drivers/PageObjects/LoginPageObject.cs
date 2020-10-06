using OpenQA.Selenium;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class LoginPageObject
    {
        private readonly IWebDriver _webDriver;

        private readonly By _submitButtonById = By.Id("submitButton");

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement UsernameTextBox => _webDriver.FindElement(By.Id("email"));
        public IWebElement PasswordTextBox => _webDriver.FindElement(By.Id("password"));

        public void ClickSubmitButton()
        {
            WebElementHelper.ClickAndWaitForPageToLoad(_webDriver, _submitButtonById);
        }

        public void LogIn(string username, string password)
        {
            UsernameTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);

            ClickSubmitButton();
        }
    }
}
