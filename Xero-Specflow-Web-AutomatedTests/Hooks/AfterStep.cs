using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;
using Xero.Specflow.Drivers;
using Xero.Specflow.Infrastructure;

namespace Xero.Specflow.Hooks
{
    [Binding]
    class AfterStep
    {
        private readonly BrowserDriver _browserDriver;

        public AfterStep(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        [AfterStep]
        public void MakeScreenshotAfterStep()
        {
            if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".png";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                Console.WriteLine($"SCREENSHOT[ {tempFileName} ]");
            }
        }
    }
}
