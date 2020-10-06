using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xero.Specflow.Contexts;
using Xero.Specflow.Helpers;

namespace Xero.Specflow.Drivers
{
    public class BrowserDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly TestContext _testContext;
        private readonly Lazy<WebDriverWait> _waitLazy;
        private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(10);
        private bool _isDisposed;

        public BrowserDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory, TestContext testContext)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _testContext = testContext;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
            _waitLazy = new Lazy<WebDriverWait>(GetWebDriverWait);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private WebDriverWait GetWebDriverWait()
        {
            return new WebDriverWait(Current, _waitDuration);
        }

        private IWebDriver GetWebDriver()
        {
            return _browserSeleniumDriverFactory.GetForBrowser(_testContext.Browser);
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
                Current.Navigate().GoToUrl($"{_testContext.Hostname}/{urlPart}");
                RetryHelper.WaitFor(() => Current.Url.EndsWith(urlPart));
            }
        }
    }
}
