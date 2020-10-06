using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Xero.Specflow.Contexts
{
    public static class TestContext
    {
        private static string _testDirectory;
        public static string TestDirectory => _testDirectory ?? (_testDirectory = AppDomain.CurrentDomain.BaseDirectory);
        public static IConfiguration Configuration;
    }
}
