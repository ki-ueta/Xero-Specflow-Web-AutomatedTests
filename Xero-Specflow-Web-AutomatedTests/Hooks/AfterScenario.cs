using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers;
using Xero.Specflow.Drivers.Interfaces;
using Xero.Specflow.Infrastructure;

namespace Xero.Specflow.Hooks
{
    [Binding]
    public class AfterScenario
    {
        private readonly BrowserDriver _browserDriver;

        public AfterScenario(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        [AfterScenario(Order = 1)]
        public void RegisterDependencies()
        {
            // TODO dispose browser properly
            _browserDriver?.Dispose();
        }
    }
}
