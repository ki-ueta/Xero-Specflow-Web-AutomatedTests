using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xero.Specflow.Drivers;

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

        [AfterStep()]
        public void MakeScreenshotAfterStep()
        {
            if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".png";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                Console.WriteLine($"SCREENSHOT[ {tempFileName} ]SCREENSHOT");
            }
        }
    }
}
