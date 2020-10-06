using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Infrastructure
{
    public class BrowserDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly TestRunContext _testRunContext;
        private readonly TimeSpan _waitDuration;
        private bool _isDisposed;

        public BrowserDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory, TestRunContext testRunContext)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _testRunContext = testRunContext;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
            _waitDuration = testRunContext.Timeout;
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;
        
        private IWebDriver GetWebDriver()
        {
            return _browserSeleniumDriverFactory.GetForBrowser(_testRunContext.Browser);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }

        public void Navigate(string urlPart)
        {
            if (!Current.Url.EndsWith(urlPart))
            {
                Current.Navigate().GoToUrl($"{_testRunContext.Hostname}/{urlPart}");
                RetryHelper.WaitFor(() => Current.Url.EndsWith(urlPart));
            }
        }
    }
}
