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

namespace Xero.Specflow.Hooks
{
    [Binding]
    public class BeforeTestRun
    {
        [BeforeTestRun (Order = 1)]
        public static void RegisterDependencies(IObjectContainer objectContainer)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(TestContext.TestDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);
            TestContext.Configuration = config;

            objectContainer.RegisterTypeAs<LoginDriver, ILoginDriver>();
            objectContainer.RegisterTypeAs<DashboardDriver, IDashboardDriver>();
            objectContainer.RegisterTypeAs<BankAccountsDriver, IBankAccountsDriver>();
        }
    }
}
