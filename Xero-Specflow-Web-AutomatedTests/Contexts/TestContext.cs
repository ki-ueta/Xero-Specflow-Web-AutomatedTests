using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Xero.Specflow.Contexts
{
    public class TestContext{
        public string Hostname => GetAppSetting("XeroUrl", "");
        public string Browser => GetAppSetting("Browser", "");
        public string Username => GetAppSetting("Username", "");
        public string Password => GetAppSetting("Password", "");
        public IConfiguration Configuration;

        private  string GetAppSetting(string key, string defaultValue)
        {
            var value = Configuration[key];
            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }
            return value;
        }
    }

    public static class BaseTestContext
    {
        private static string _testDirectory;
        public static string TestDirectory => _testDirectory ?? (_testDirectory = AppDomain.CurrentDomain.BaseDirectory);
    }
}
