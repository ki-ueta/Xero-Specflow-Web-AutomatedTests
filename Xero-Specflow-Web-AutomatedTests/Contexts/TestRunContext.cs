using Microsoft.Extensions.Configuration;
using System;

namespace Xero.Specflow.Contexts
{
    public class TestRunContext{

        public string Hostname => GetAppSetting("XeroUrl", "");
        public string Browser => GetAppSetting("Browser", "");
        public string Username => GetAppSetting("Username", "");
        public string Password => GetAppSetting("Password", "");
        public string FirefoxBinaryPath => GetAppSetting("FirefoxBinaryPath",
             @"C:\Program Files\Mozilla Firefox\firefox.exe");
        public TimeSpan Timeout => TimeSpan.FromSeconds(double.Parse(GetAppSetting("TimeoutInSeconds", "")));

        private  string GetAppSetting(string key, string defaultValue)
        {
            var value = TestContext.Configuration[key];
            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }
            return value;
        }
    }
}
