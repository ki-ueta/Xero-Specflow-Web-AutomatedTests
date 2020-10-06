using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using Xero.Specflow.Contexts;

namespace Xero.Specflow.Drivers
{
    public class BrowserSeleniumDriverFactory
    {
        private readonly TestContext _testContext;

        public BrowserSeleniumDriverFactory(TestContext testContext)
        {
            _testContext = testContext;
        }

        public IWebDriver GetForBrowser(string browserId)
        {
            string lowerBrowserId = browserId.ToUpper();
            switch (lowerBrowserId)
            {
                case "CHROME": return GetChromeDriver(false);
                case "CHROME-HEADLESS": return GetChromeDriver(true);
                case "FIREFOX": return GetFirefoxDriver();
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }

        private IWebDriver GetFirefoxDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService(BaseTestContext.TestDirectory);
            return new FirefoxDriver(firefoxDriverService)
            {
                Url = _testContext.Hostname,
            };
        }

        private IWebDriver GetChromeDriver(bool isHeadless)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService(BaseTestContext.TestDirectory);

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-notifications");

            if (isHeadless)
            {
                chromeOptions.AddArgument("headless");
            }

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions)
            {
                Url = _testContext.Hostname
            };

            return chromeDriver;
        }

        private IWebDriver GetInternetExplorerDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
            };
            return new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(BaseTestContext.TestDirectory), internetExplorerOptions)
            {
                Url = _testContext.Hostname,
            };
        }
    }
}
