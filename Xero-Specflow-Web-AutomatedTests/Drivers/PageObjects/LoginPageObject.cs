using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers.PageObjects
{
    class LoginPageObject
    {
        private readonly IWebDriver _webDriver;

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement usernameTextBox => _webDriver.FindElement(By.Id("email"));
        public IWebElement passwordTextBox => _webDriver.FindElement(By.Id("password"));
        public IWebElement submitButton => _webDriver.FindElement(By.Id("submitButton"));

        public void LogIn(string username, string password)
        {
            usernameTextBox.SendKeys(username);
            passwordTextBox.SendKeys(password);

            submitButton.Submit();

            RetryHelper.WaitFor(() => _webDriver.Url.EndsWith("/Dashboard"));
        }
    }
}
