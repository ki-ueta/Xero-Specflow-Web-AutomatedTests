using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Xero.Specflow.Contexts;

namespace Xero.Specflow.Infrastructure
{
    public class BrowserSeleniumDriverFactory
    {
        private readonly TestRunContext _testRunContext;

        public BrowserSeleniumDriverFactory(TestRunContext testRunContext)
        {
            _testRunContext = testRunContext;
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
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService(TestContext.TestDirectory);
            firefoxDriverService.FirefoxBinaryPath = _testRunContext.FirefoxBinaryPath;
            // TODO add required browser options to make it consistent

            return new FirefoxDriver(firefoxDriverService)
            {
                Url = _testRunContext.Hostname,
            };
        }

        private IWebDriver GetChromeDriver(bool isHeadless)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService(TestContext.TestDirectory);

            // TODO add required browser options to make it consistent
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-notifications");

            if (isHeadless)
            {
                chromeOptions.AddArgument("headless");
            }

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions)
            {
                Url = _testRunContext.Hostname
            };

            return chromeDriver;
        }
    }
}
